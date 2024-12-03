using AutoMapper;
using School.DAL.Interface;
using School.Domain.Models;
using School.Domain.ModelsDb;
using School.Domain.Response;
using School.Service.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Realizations
{
    public class ProductsService : IProductsService
    {
        private readonly IBaseStorage<ProductsDb> _productsStorage;
        private IMapper _mapper { get; set; }

        MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
        {
            p.AddProfile<AppMappingProfile>();
        });

        public ProductsService(IBaseStorage<ProductsDb> productsStorage)
        {
            _productsStorage = productsStorage;
            _mapper = mapperConfiguration.CreateMapper();
        }
        public BaseResponse<List<Products>> GetALLProductsByCategory(Guid Id)
        {
            try
            {
                var productsDb = _productsStorage.GetAll().Where(x => Id == x.Id_Category).OrderBy(p => p.CreatedAt).ToList();

                var result = _mapper.Map<List<Products>>(productsDb);
                if(result.Count == 0)
                {
                    return new BaseResponse<List<Products>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<List<Products>>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch(Exception ex)
            {
                return new BaseResponse<List<Products>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
