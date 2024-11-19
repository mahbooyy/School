using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Enum; 

namespace School.Domain.Response
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }

        public StatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
    public interface IBaseResponse<T>
    {
        T Data { get; set; }
    }
    public enum StatusCode
    {
        OK = 200,
        BadRequest = 400,
        NotFount = 404,
        InternalServerError = 500,
    }
}
