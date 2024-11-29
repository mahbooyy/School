using AutoMapper;
using School.DAL.Interface;
using School.Domain.ModelsDb;
using School.Domain.Response;
using School.Domain.Validators;
using School.Service.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace School.Service.Realizations
{
    public class CategoryProductsService : ICategoryProductsService
    {
        private readonly IBaseStorage<CategoryDb> _categoryProductsStorage;
        private IMapper _mapper { get; set; }
        private CategoryValidator _validationRules { get; set; }

        MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
        {
            p.AddProfile<AppMappingProfile>();
        });

        public CategoryProductsService(IBaseStorage<CategoryDb> categoryProductsStorage)
        {
            _categoryProductsStorage = categoryProductsStorage;
            _mapper = mapperConfiguration.CreateMapper();
            _validationRules = new CategoryValidator();
        }

        // Реализуем метод GetALLCategoryProducts() из интерфейса
        public BaseResponse<List<CategoryDb>> GetALLCategoryProducts()
        {
            try
            {
                // Получаем данные из хранилища и сортируем
                var categoryDb = _categoryProductsStorage.GetAll().OrderBy(p => p.CreatedAt).ToList();

                // Если ничего не найдено
                if (categoryDb.Count == 0)
                {
                    return new BaseResponse<List<CategoryDb>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                // Возвращаем успешный ответ с данными
                return new BaseResponse<List<CategoryDb>>()
                {
                    Data = categoryDb,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                // Обрабатываем исключение и возвращаем ошибку
                return new BaseResponse<List<CategoryDb>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
