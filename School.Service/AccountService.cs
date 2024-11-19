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

namespace School.Service
{
    public class AccountService : IAccountService
    {
        private readonly IBaseStorage<UserDb> _userStorage;

        private IMapper _mapper { get; set; }

        MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
       {
           p.AddProfile<AppMappingProfile>();
       });

        public AccountService(IBaseStorage<UserDb> userStorage)
        {
            _userStorage = userStorage;
            _mapper = mapperConfiguration.CreateMapper();
        }

        public async Task<BaseResponse<User>> Login(User model)
        {
            try
            {
                var userdb = _mapper.Map<UserDb>(model);

                if(await _userStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email) == null)
                {
                    return new BaseResponse<User>()
                    {
                        Description = "Пользователь не найден"
                    };
                }
                if(userdb.Password != model.Password)
                {
                    return new BaseResponse<User>()
                    {
                        Description = "Неверный пароль или почта"
                    };
                }
                return new BaseResponse<User>()
                {
                    Data = model,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public async Task<BaseResponse<User>> Register(User model)
        {
            try
            {
                model.PathImage = "/images/user.png";
                model.CreatedAt = DateTime.Now;

                var userDb = _mapper.Map<UserDb>(model);

                if (await _userStorage.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email) != null)
                {
                    return new BaseResponse<User>()
                    {
                        Description = "Пользователь с такой почтой уже есть"
                    };
                }
                await _userStorage.Add(userDb);

                return new BaseResponse<User>()
                {
                    Data = model,
                    Description = "Пользователь не зарегистрирован",
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
