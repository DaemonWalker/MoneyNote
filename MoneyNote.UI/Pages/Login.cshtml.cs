using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoneyNote.DomainModel;
using MoneyNote.Logic;

using DomainModel = MoneyNote.DomainModel;

namespace MoneyNote.UI.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserLogic userLogic;
        public LoginModel(UserLogic userLogic)
        {
            this.userLogic = userLogic;
        }
        public async Task<IActionResult> OnPostAsync(string account, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(account) && string.IsNullOrEmpty(password))
                {
                    return LocalRedirect("/");
                }

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                var user = userLogic.Login(new DomainModel.LoginModel() { EMail = account, Password = password });
                if (user == null)
                {
                    return LocalRedirect("/");
                }
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.ID)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            }
            finally
            {

            }
            return LocalRedirect("/");

        }
    }
}
