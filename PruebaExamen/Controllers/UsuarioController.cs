using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PruebaExamen.Models;
using PruebaExamen.Repositories;

namespace PruebaExamen.Controllers
{
    public class UsuarioController : Controller
    {
        private RepositoryUsuarios repo;

        public UsuarioController(RepositoryUsuarios repo)
        {
            this.repo = repo;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string nombre, string contrasenha)
        {
            Usuario user = this.repo.GetUserByNamePass(nombre, contrasenha);
            if (user != null)
            {
                ClaimsIdentity identity =
                    new ClaimsIdentity
                    (CookieAuthenticationDefaults.AuthenticationScheme,
                    ClaimTypes.Name, ClaimTypes.Role);

                Claim claimNombre = new Claim(ClaimTypes.Name, user.Nombre);
                identity.AddClaim(claimNombre);

                Claim claimID =
                    new Claim("ID", user.Id.ToString());
                identity.AddClaim(claimID);

                ClaimsPrincipal userPrincipal =
                    new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme
                    , userPrincipal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrectos";
                return View();
            }
        }
    }
}
