using FluentValidation;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace School.Domain.Validators
{
    public class OrderValidator : AbstractValidator<Orders>
    {
        public OrderValidator() 
        {
            RuleFor(order => order.Id_User).NotEmpty().WithMessage("Id пользователя обязателен");
            RuleFor(order => order.Id_Product).NotEmpty().WithMessage("Id товара обязателен");
            RuleFor(order => order.Price).NotEmpty().WithMessage("Цена должна быть больше нуля");

        }
    }
}
