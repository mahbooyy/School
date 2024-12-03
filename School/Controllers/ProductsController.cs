using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Domain.ViewModels.LoginAndRegistration;
using School.Service;
using School.Service.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        private IMapper _mapper { get; set; }

        MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
        {
            p.AddProfile<AppMappingProfile>();
        });

        public ProductsController(IProductsService ProductsService)
        {
            _productsService = ProductsService;
            _mapper = mapperConfiguration.CreateMapper();
        }

        public IActionResult ListOfProducts(Guid Id)
        {
            var result = _productsService.GetALLProductsByCategory(Id);
            ListOfProductsViewModel listProducts = new ListOfProductsViewModel
            {
                Products = _mapper.Map<List<ProductsForListOfProductsViewModel>>(result.Data),
                Id_Products = Id
            };

            return View(listProducts);
        }
    }
}
