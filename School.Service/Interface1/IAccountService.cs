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
        Task<BaseResponse<ClaimsIdentity>> Register(User model);
        Task<BaseResponse<ClaimsIdentity>> Login(User model);
    }
}
