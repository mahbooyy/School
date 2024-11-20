using System;
using System.Threading.Tasks;
using AutoMapper;
using School.Domain;
using School.Domain.Models;
using School.Domain.ModelsDb;
using School.Domain.Response;
using School.Service.Interface;
using Microsoft.EntityFrameworkCore;
using School.DAL.Interface;
using System.Security.Claims;
using School.Domain.Helpers;

namespace School.Service
{
    public class AccountService : IAccountService
    {
        private readonly IBaseStorage<UserDb> _UserStorage;
        private IMapper _mapper { get; set; }

        MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
        {
            p.AddProfile<AppMappingProfile>();
        });

        public AccountService(IBaseStorage<UserDb> userStorage)
        {
            _UserStorage = userStorage;
            _mapper = mapperConfiguration.CreateMapper();
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(User model)
        {
            try
            {
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
            catch (Exception ex)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(User model)
        {
            try
            {
                model.PathImage = "";
                model.CreatedAt = DateTime.Now;
                model.Password = HashPasswordHelper.HashPassword(model.Password);

                var userdb = _mapper.Map<UserDb>(model);

                if (await _UserStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email) != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь с такой почтой уже есть",
                    };
                }

                await _UserStorage.Add(userdb);

                // Создайте ClaimsIdentity после регистрации пользователя
                var claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, model.Email),

                }, "Password");

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = claimsIdentity, // Передаем ClaimsIdentity
                    Description = "Пользователь зарегистрирован",
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
