using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PruebaExamen.Data;
using PruebaExamen.Models;

namespace PruebaExamen.Repositories
{
    public class RepositoryUsuarios
    {
        private AppDBContext context;

        public RepositoryUsuarios(AppDBContext context)
        {
            this.context = context;
        }

        public Usuario GetUserByNamePass(string nombre, string contrasenha)
        {
            return this.context.Usuarios
                .Where(x => x.Nombre == nombre && x.Contrasenha == contrasenha)
                .AsEnumerable().FirstOrDefault();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync
            (CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Home", "Index");
        }
    }
}
