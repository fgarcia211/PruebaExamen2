using Microsoft.AspNetCore.Mvc;
using PruebaExamen.Repositories;

namespace PruebaExamen.Controllers
{
    public class ArticuloController : Controller
    {
        private RepositoryArticulos repo;

        public ArticuloController(RepositoryArticulos repo)
        {
            this.repo = repo;
        }
        public IActionResult VistaArticulos()
        {
            return View(this.repo.GetAllArticulos());
        }

    }
}
