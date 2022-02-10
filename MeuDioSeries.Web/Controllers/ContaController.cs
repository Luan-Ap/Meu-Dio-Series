using MeuDioSeries.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MeuDioSeries.Web.Controllers
{
    public class ContaController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UsuarioViewModel usuario)
        {
            if(usuario.Email.Equals("luan.admin@email.com") && usuario.Senha.Equals("adminLuan123"))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, "CookieSeries");
                var claimPrincipal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = usuario.LembrarMe
                };

                await HttpContext.SignInAsync("CookieSeries", claimPrincipal, authProperties);

                return RedirectToAction("Index", "Home");
            }
            else if (usuario.Email.Equals("luan.visitante@email.com") && usuario.Senha.Equals("visitanteLuan123"))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Email),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, "Visitante")
                };

                var identity = new ClaimsIdentity(claims, "CookieSeries");
                var claimPrincipal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = usuario.LembrarMe
                };

                await HttpContext.SignInAsync("CookieSeries", claimPrincipal, authProperties);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Login Inválido");
            }

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieSeries");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AcessoNegado()
        {
            return View();
        }
    }
}
