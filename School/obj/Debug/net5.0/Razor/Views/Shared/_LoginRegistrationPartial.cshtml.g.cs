#pragma checksum "C:\Users\kab-35-17\Desktop\School\School\Views\Shared\_LoginRegistrationPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d37a06f3e8fae9b3ec34ccc158dc828fc1e37d41"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TravelAgency.Pages.Shared.Views_Shared__LoginRegistrationPartial), @"mvc.1.0.view", @"/Views/Shared/_LoginRegistrationPartial.cshtml")]
namespace TravelAgency.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\kab-35-17\Desktop\School\School\Views\_ViewImports.cshtml"
using TravelAgency;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d37a06f3e8fae9b3ec34ccc158dc828fc1e37d41", @"/Views/Shared/_LoginRegistrationPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af0b1e74f3cfc9b719dcd52bea3bcb90b7eb3ffb", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LoginRegistrationPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form form_signin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form form_signup"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""container-login-registration"">
    <div class=""block-container"">
        <div class=""block"">
            <section class=""block_item block-item"">
                <h2 class=""block-item_title"">У вас уже есть аккаунт?</h2>
                <button class=""signin-btn block-item_btn"">Войти</button>
            </section>

            <section class=""block_item block-item"">
                <h2 class=""block-item_title"">У вас нет аккаунта?</h2>
                <button class=""signup-btn block-item_btn"">Зарегистрироваться</button>
            </section>
        </div>

        <div class=""form-box"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d37a06f3e8fae9b3ec34ccc158dc828fc1e37d414503", async() => {
                WriteLiteral("\r\n                <h3 class=\"form_title\">Вход</h3>\r\n                <label id=\"signin_email\">\r\n                    <input type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 797, "\"", 811, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <span>Почта</span>\r\n                </label>\r\n                <label id=\"signin_password\">\r\n                    <input type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 967, "\"", 981, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <span>Пароль</span>\r\n                </label>\r\n                <div class=\"form-btn form_btn_signin\">Войти</div>\r\n                <div id=\"error-messages-signin\"></div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d37a06f3e8fae9b3ec34ccc158dc828fc1e37d416690", async() => {
                WriteLiteral("\r\n                <h3 class=\"form_title\">Регистрация</h3>\r\n                <label id=\"signup_login\">\r\n                    <input type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1383, "\"", 1397, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <span>Логин</span>\r\n                </label>\r\n                <label id=\"signup_email\">\r\n                    <input type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1550, "\"", 1564, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <span>Почта</span>\r\n                </label>\r\n                <label id=\"signup_password\">\r\n                    <input type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1720, "\"", 1734, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <span>Пароль</span>\r\n                </label>\r\n                <label id=\"signup_confirm_password\">\r\n                    <input type=\"text\"");
                BeginWriteAttribute("placeholder", " placeholder=\"", 1899, "\"", 1913, 0);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    <span>Подтвердите пароль</span>\r\n                </label>\r\n                <div class=\"form-btn form_btn_signup\">Зарегистрироваться</div>\r\n                <div id=\"error-messages-signup\"></div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"overlay\"></div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
