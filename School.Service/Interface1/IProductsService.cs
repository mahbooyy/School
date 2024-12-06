using School.Domain.Models;
using School.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Interface1
{
    public interface IProductsService
    {
        BaseResponse<List<Products>> GetALLProductsByCategory(Guid Id);

        BaseResponse<List<Products>> GetProductsByFilter(ProductsFilter filter);

        BaseResponse<List<Products>> GetProductsById(Guid Id);

        BaseResponse<List<PictureProduct>> GetPictureProductById(Guid Id);
    }
}
