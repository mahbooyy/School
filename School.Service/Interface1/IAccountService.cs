using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Models;
using School.Domain.Response;

namespace School.Service.Interface
{
    public interface IAccountService
    {
        Task<BaseResponse<string>> Register(User model);
        Task<BaseResponse<ClaimsIdentity>> Login(User model);

        Task<BaseResponse<ClaimsIdentity>> ConfirmEmail(User model, string code,string confirmCode);

        Task<BaseResponse<ClaimsIdentity>> IsCreatedAccount(User model);
    }
}
