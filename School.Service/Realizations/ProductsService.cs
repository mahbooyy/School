using AutoMapper;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using School.DAL.Interface;
using School.DAL.Storage;
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

        private readonly IBaseStorage<PictureProductDb> _pictureproductStorage;

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
                if (result.Count == 0)
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
            catch (Exception ex)
            {
                return new BaseResponse<List<Products>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
        public BaseResponse<List<Products>> GetProductsByFilter(ProductsFilter filter)
        {
            try
            {
                var productFilter = GetALLProductsByCategory(filter.Id_Category).Data;

                if (filter != null && productFilter != null)
                {
                    // Фильтрация по цене
                    if (filter.PriceMax > 0 || filter.PriceMin > 0)
                    {
                        productFilter = productFilter.Where(f => f.Price >= filter.PriceMin && f.Price <= filter.PriceMax).ToList();
                    }

                    // Сортировка
                    if (!string.IsNullOrEmpty(filter.SortBy))
                    {
                        switch (filter.SortBy)
                        {
                            case "Price":
                                productFilter = filter.IsAscending
                                    ? productFilter.OrderBy(f => f.Price).ToList() // Сортировка по цене от дешевых к дорогим
                                    : productFilter.OrderByDescending(f => f.Price).ToList(); // Сортировка по цене от дорогих к дешевым
                                break;

                            case "Time":
                                productFilter = filter.IsAscending
                                    ? productFilter.OrderBy(f => f.CreatedAt).ToList() // Сортировка по времени от старых к новым
                                    : productFilter.OrderByDescending(f => f.CreatedAt).ToList(); // Сортировка по времени от новых к старым
                                break;

                            case "Name":
                                productFilter = filter.IsAscending
                                    ? productFilter.OrderBy(f => f.Name).ToList() // Сортировка по алфавиту от А до Я
                                    : productFilter.OrderByDescending(f => f.Name).ToList(); // Сортировка по алфавиту от Я до А
                                break;

                            default:
                                break;
                        }
                    }

                    return new BaseResponse<List<Products>>
                    {
                        Data = productFilter,
                        Description = "Отфилтрованные данные",
                        StatusCode = StatusCode.OK
                    };
                }
                else
                {
                    return new BaseResponse<List<Products>>()
                    {
                        Description = "Неверные фильтры или отсутствуют данные для фильтрации",
                        StatusCode = StatusCode.BadRequest
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Products>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<Products>> GetProductsById(Guid id)
        {
            try
            {
                var productsDb = await _productsStorage.Get(id);

                var result = _mapper.Map<Products>(productsDb);
                if (result == null)
                {
                    return new BaseResponse<Products>()
                    {
                        Description = "Найдено в элементов",
                        StatusCode = StatusCode.OK
                    };
                }
                return new BaseResponse<Products>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK

                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Products>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public BaseResponse<List<PictureProduct>> GetPicturByIdProduct(Guid Id)
        {
            try
            {
                var pictureDb = _pictureproductStorage.GetAll().Where(x => Id == x.Id_Product).ToList();

                var result = _mapper.Map<List<PictureProduct>>(pictureDb);

                // Сравнение с количеством элементов в коллекции
                if (result.Count == 8)  // Используем оператор сравнения (==)
                {
                    return new BaseResponse<List<PictureProduct>>()
                    {
                        Description = "Найдено 8 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                // Можно вернуть другие данные или ошибки, если нужно
                return new BaseResponse<List<PictureProduct>>()
                {
                    Description = "Количество элементов не соответствует ожиданиям.",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<PictureProduct>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}

    