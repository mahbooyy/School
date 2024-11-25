using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Domain.ViewModels.LoginAndRegistration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Schoolerror;
using School.Domain.Models;
using School.Domain.Response;
using AutoMapper;
using School.Service.Interface;
using School.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using School.Domain.Enum;

namespace School.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;

        private IMapper _mapper { get; set; }

        MapperConfiguration mapperConfiguration = new MapperConfiguration(p =>
        {
            p.AddProfile<AppMappingProfile>();
        });
        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
            _mapper = mapperConfiguration.CreateMapper();
        }

        public IActionResult SiteInformation()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);

                var response = await _accountService.Login(user);
                if(response.StatusCode == Domain.Response.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));
                    return Ok(model);
                }
                ModelState.AddModelError("", response.Description);
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToList();
            return BadRequest(errors);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);

                var confirm = _mapper.Map<ConfirmEmailViewModel>(model);

                var code = await _accountService.Register(user);

                confirm.GeneratedCode = code.Data;

                return Ok(confirm);
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage)
                                           .ToList();
            return BadRequest(errors);
        }
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SiteInformation", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailViewModel confirmEmailModel)
        {
            // Преобразуем ConfirmEmailViewModel в модель User
            var user = _mapper.Map<User>(confirmEmailModel);

            // Вызываем метод ConfirmEmail из сервиса
            var response = await _accountService.ConfirmEmail(user, confirmEmailModel.GeneratedCode, confirmEmailModel.CodeConfirm);

            // Если код подтверждения правильный, выполняем аутентификацию
            if (response.StatusCode == Domain.Response.StatusCode.OK)
            {
                // Входим в систему с новым пользовательским объектом
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(response.Data));
                return Ok(confirmEmailModel); // Возвращаем успешный ответ
            }

            // Если код подтверждения неверный, добавляем ошибку в модель
            ModelState.AddModelError("", response.Description);

            // Получаем все ошибки из ModelState и возвращаем их в виде списка
            var errors = ModelState.Values
                                   .SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)
                                   .ToList();

            return BadRequest(errors); // Возвращаем ошибку с описанием
        }

    }
}
