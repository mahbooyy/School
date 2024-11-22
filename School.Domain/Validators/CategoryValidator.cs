using FluentValidation;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {

        public CategoryValidator() 
        {
            RuleFor(category => category.Id).NotEmpty().WithMessage("Id категории обязателен");
            RuleFor(category => category.Id_Product).NotEmpty().WithMessage("Id товара обязателен");
            RuleFor(category => category.PathImage).NotEmpty().WithMessage("Путь изображения обязателен");

        }
    }
}
