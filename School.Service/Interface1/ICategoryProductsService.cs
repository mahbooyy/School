using School.Domain.ModelsDb;
using School.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Interface1
{
    public interface ICategoryProductsService
    {
        BaseResponse<List<CategoryDb>> GetALLCategoryProducts();
    }
}
