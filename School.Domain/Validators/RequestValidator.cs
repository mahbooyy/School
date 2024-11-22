using FluentValidation;
using School.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Validators
{
    public class RequestValidator : AbstractValidator<Request>
    {

        public RequestValidator() 
        {
            RuleFor(request => request.Id_User).NotEmpty().WithMessage("Id пользователя обязателен");
            RuleFor(request => request.Description).NotEmpty().WithMessage("Описание обязательно");
            RuleFor(request => request.Status).IsInEnum().WithMessage("Статус должен быть допустимым значением перечисления");
            RuleFor(request => request.Id_Order).NotEmpty().WithMessage("Id заказа обязателен");
        }

    }
}
