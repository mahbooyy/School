using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Domain.ViewModels; // Убедитесь, что подключили правильное пространство имен для ViewModel
using School.Domain.ViewModels.LoginAndRegistration;
using School.Service;
using School.Service.Interface1;
using System.Collections.Generic; // Убедитесь, что подключили правильное пространство имен для сервиса

namespace School.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryProductsService _CategoryProductsService;
        private IMapper _mapper {  get; set; }

        MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
        {
            p.AddProfile<AppMappingProfile>();
        });

        // Конструктор для внедрения зависимостей
        public CategoryController(ICategoryProductsService CategoryProductsService)
        {
            _CategoryProductsService = CategoryProductsService;
            _mapper = mapperConfiguration.CreateMapper();
        }

        // Метод для отображения списка стран
        public IActionResult CategoryProducts()
        {
            // Получаем данные через сервис
            var result = _CategoryProductsService.GetALLCategoryProducts();

            // Маппинг данных из модели сервиса в модель представления
            var listOfCategoryProducts = _mapper.Map<List<CategoryProductsViewModel>>(result.Data);

            // Возвращаем представление с моделью данных
            return View(listOfCategoryProducts);
        }
    }
}
