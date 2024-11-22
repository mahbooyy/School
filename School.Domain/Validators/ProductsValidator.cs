using FluentValidation;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Validators
{
    public class ProductsValidator : AbstractValidator<Products>
    {

        public ProductsValidator() 
        {
            RuleFor(product => product.Id_Category).NotEmpty().WithMessage("Id категории обязателен");
            RuleFor(product => product.Product).NotEmpty().WithMessage("Название продукта обязательно");
            RuleFor(product => product.Name).NotEmpty().WithMessage("Название товара обязательно");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Цена товара должна быть больше нуля");

        }

    }
}
