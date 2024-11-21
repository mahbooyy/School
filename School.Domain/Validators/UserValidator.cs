using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using School.Domain.Models;

namespace School.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Password).NotEmpty().WithMessage("Пароль обязателен")
            .MinimumLength(6).WithMessage("Пароль должен содержать не более 6 символов");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Email обязателен")
                .EmailAddress().WithMessage("Неверный формат Email");
        }
    }
}
