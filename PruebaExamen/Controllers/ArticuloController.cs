using Microsoft.AspNetCore.Mvc;
using PruebaExamen.Models;
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

        public IActionResult _PaginacionAjax(int? posicion)
        {
            int numarticulos = 0;
            ArticuloXML articulo = this.repo.GetArticuloXPosicion
                (posicion.Value, ref numarticulos);

            ViewData["DATOS"] = "Articulo " + (posicion + 1) + " de " + numarticulos;

            int siguiente = posicion.Value + 1;
            if (siguiente >= numarticulos)
            {
                siguiente = 0;
            }
            int anterior = posicion.Value - 1;
            if (anterior < 0)
            {
                anterior = numarticulos - 1;
            }
            ViewData["SIGUIENTE"] = siguiente;
            ViewData["ANTERIOR"] = anterior;

            return PartialView("_PaginacionAjax",articulo);
        }

    }
}
