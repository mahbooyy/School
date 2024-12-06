using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Models;
using School.Domain.ViewModels.LoginAndRegistration;
using School.Service.Interface1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        // Конструктор с внедрением зависимостей через DI
        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        // Получение списка продуктов по категории
        public async Task<IActionResult> ListOfProducts(Guid Id)
        {
            var result = await _productsService.GetALLProductsByCategory(Id);

            // Проверка на наличие данных в ответе
            if (result?.Data == null || result.Data.Count == 0)
            {
                // Если нет данных, возвращаем пустую модель или ошибку
                return View(new ListOfProductsViewModel { Id_Products = Id });
            }

            ListOfProductsViewModel listProducts = new ListOfProductsViewModel
            {
                Products = _mapper.Map<List<ProductsForListOfProductsViewModel>>(result.Data),
                Id_Products = Id
            };

            return View(listProducts);
        }

        // Фильтрация продуктов
        [HttpPost]
        public async Task<IActionResult> Filter([FromBody] ProductsFilter filter)
        {
            // Вызов асинхронного метода фильтрации
            var result = await _productsService.GetProductsByFilter(filter);

            if (result?.Data == null)
            {
                return Json(new List<ProductsForListOfProductsViewModel>());
            }

            var filteredProducts = _mapper.Map<List<ProductsForListOfProductsViewModel>>(result.Data);
            return Json(filteredProducts);
        }

        // Страница продукта
        public async Task<IActionResult> ProductPage(Guid Id)
        {
            // Получение продукта по ID
            var resultProducts = await _productsService.GetProductsById(Id);

            // Проверка на наличие данных в ответе
            if (resultProducts?.Data == null)
            {
                return NotFound();  // Возвращаем ошибку 404, если продукт не найден
            }

            // Получение изображений продукта
            var resultPicture = await _productsService.GetPictureProductById(Id);

            ProductsPageViewModel products = _mapper.Map<ProductsPageViewModel>(resultProducts.Data);
            products.PictureProducts = _mapper.Map<List<PictureProductsViewModel>>(resultPicture?.Data);

            return View(products);
        }
    }
}
