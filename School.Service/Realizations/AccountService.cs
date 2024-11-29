using System;
using System.Threading.Tasks;
using AutoMapper;
using School.Domain.Models;
using School.Domain.ModelsDb;
using School.Domain.Response;
using School.Service.Interface;
using Microsoft.EntityFrameworkCore;
using School.DAL.Interface;
using System.Security.Claims;
using School.Domain.Helpers;
using FluentValidation;
using School.Domain.Validators;
using System.Linq;
using MimeKit;
using System.IO;



namespace School.Service.Realizations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseStorage<UserDb> _UserStorage;
        private IMapper _mapper { get; set; }

        private UserValidator _validationrules { get; set; }

        MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
        {
            p.AddProfile<AppMappingProfile>();
        });

        public AccountService(IBaseStorage<UserDb> userStorage)
        {
            _UserStorage = userStorage;
            _mapper = mapperConfiguration.CreateMapper();
            _validationrules = new UserValidator();
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(User model)
        {
            try
            {
                await _validationrules.ValidateAndThrowAsync(model);
                var userdb = await _UserStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email);

                if (userdb == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден"
                    };
                }

                if (userdb.Password != HashPasswordHelper.HashPassword(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль или почта"
                    };
                }

                // ClaimsIdentity для аутентификации
                var claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, model.Email),

                }, "Password");

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = claimsIdentity, // Передаем ClaimsIdentity
                    StatusCode = StatusCode.OK
                };
            }
            catch (ValidationException ex)
            {
                var errorMessages = string.Join(";", ex.Errors.Select(e => e.ErrorMessage));
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = errorMessages,
                    StatusCode = StatusCode.BadRequest
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<string>> Register(User model)
        {
            try
            {
                // Генерация кода подтверждения
                Random random = new Random();
                string confirmationCode = $"{random.Next(10)}{random.Next(10)}{random.Next(10)}{random.Next(10)}";

                // Проверка наличия пользователя с таким email
                if (await _UserStorage.GetAll().AnyAsync(x => x.Email == model.Email))
                {
                    return new BaseResponse<string>()
                    {
                        Description = "Пользователь с такой почтой уже есть",
                        StatusCode = StatusCode.BadRequest
                    };
                }

                // Отправка email с кодом подтверждения
                await SendEmail(model.Email, confirmationCode);

                // Успешный ответ
                return new BaseResponse<string>()
                {
                    Data = confirmationCode,
                    Description = "Письмо отправлено",
                    StatusCode = StatusCode.OK
                };
            }
            catch (ValidationException ex)
            {
                // Получение сообщений об ошибках валидации
                var errorMessages = string.Join(";", ex.Errors.Select(e => e.ErrorMessage));
                return new BaseResponse<string>()
                {
                    Description = errorMessages,
                    StatusCode = StatusCode.BadRequest
                };
            }
            catch (Exception ex)
            {
                // Обработка других исключений
                return new BaseResponse<string>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task SendEmail(string email, string confirmationCode)
        {
            // Путь к файлу с паролем
            string path = "D:\\tizul\\EtilPassword\\password.txt";
            // Создание сообщения
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "Karandash.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = "Добро пожаловать!";
            emailMessage.Body = new TextPart("html")
            {
                Text = @"
            <html>
                <head>
                    <style>
                        body {
                            font-family: Arial, sans-serif;
                            background-color: #f2f2f2;
                            margin: 0;
                            padding: 0;
                        }
                        .container {
                            max-width: 600px;
                            margin: 20px auto;
                            padding: 20px;
                            background-color: #fff;
                            border-radius: 10px;
                            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
                        }
                        .header {
                            text-align: center;
                            margin-bottom: 20px;
                        }
                        .message {
                            font-size: 16px;
                            line-height: 1.6;
                        }
                        .container-code {
                            background-color: #f0f0fe;
                            padding: 10px;
                            border-radius: 5px;
                            font-weight: bold;
                            text-align: center;
                        }
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>
                            <h1>Добро пожаловать на сайт КарандашMD!</h1>
                        </div>
                        <div class='message'>
                            <p>Пожалуйста, введите данный код на сайте, чтобы подтвердить ваш email и завершить регистрацию:</p>
                            <div class='container-code'>
                                <p>" + confirmationCode + @"</p>
                            </div>
                        </div>
                    </div>
                </body>
            </html>"
            };

            // Чтение пароля из файла
            string password;
            using (StreamReader reader = new StreamReader(path))
            {
                password = await reader.ReadToEndAsync();
            }

            // Отправка письма через SMTP
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, true);
                    await client.AuthenticateAsync("toptopxlopxlop1@gmail.com", password.Trim());
                    await client.SendAsync(emailMessage);
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }
        public async Task<BaseResponse<ClaimsIdentity>> ConfirmEmail(User model, string code, string confirmCode)
        {
            try
            {
                if (code != confirmCode)
                {
                    throw new Exception("Неверный код! Регистрация не выполнена.");
                }

                model.PathImage = "/Images/user.png";
                model.CreatedAt = DateTime.Now;
                model.Password = HashPasswordHelper.HashPassword(model.Password);

                await _validationrules.ValidateAndThrowAsync(model);

                var userdb = _mapper.Map<UserDb>(model);

                await _UserStorage.Add(userdb);

                var result = AuthenticateUserHelper.Authenticate(_mapper.Map<User>(userdb));

                return new BaseResponse<ClaimsIdentity>
                {
                    Data = result,
                    Description = "Объект добавился",
                    StatusCode = StatusCode.OK


                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<BaseResponse<ClaimsIdentity>> IsCreatedAccount(User model)
        {
            try
            {
                var userDb = new UserDb();
                if (await _UserStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email) == null)
                {
                    model.Password = "google";
                    model.CreatedAt = DateTime.Now;

                    userDb = _mapper.Map<UserDb>(model);

                    await _UserStorage.Add(userDb);

                    var resultRegister = AuthenticateUserHelper.Authenticate(model);
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Data = resultRegister,
                        Description = "Объект добавился",
                        StatusCode = StatusCode.OK
                    };
                }

                var resultLogin = AuthenticateUserHelper.Authenticate(model);
                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = resultLogin,
                    Description = "Объект уже был создан",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
