using FluentValidation;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Validators
{
    public class PictureProductsValidator : AbstractValidator<PictureProduct>
    {

        public PictureProductsValidator() 
        {
            RuleFor(picture => picture.PathImage).NotEmpty().WithMessage("Путь изображения обязателен");
            RuleFor(picture => picture.Id_Product).NotEmpty().WithMessage("Id продукта обязательно");

        }


    }
}
