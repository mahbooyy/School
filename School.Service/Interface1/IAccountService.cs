using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Models;
using School.Domain.Response;

namespace School.Service.Interface
{
    public interface IAccountService
    {
        Task<BaseResponse<User>> Register(User model);
        Task<BaseResponse<User>> Login(User model);
    }
}
