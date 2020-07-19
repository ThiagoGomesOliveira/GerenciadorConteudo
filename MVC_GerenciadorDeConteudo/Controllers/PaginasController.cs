using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class PaginasController : Controller
    {
        private const string url = "/Paginas";
        // GET: Paginas
        public ActionResult Index()
        {
            ViewBag.Paginas = new Business.Pagina().Listar();
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public void Criar()
        {
            
            DateTime data;
            DateTime.TryParse(Request["Data"], out data);
            var pagina = new Business.Pagina()
            {
                Id = Convert.ToInt32(Request["Id"]),
                Nome = Request["Nome"],
                Data = data,
                Conteudo = Request["Conteudo"]
            };
            pagina.Save();

            Response.Redirect(url);
        }

        public ActionResult Editar(int id)
        {
            var pagina = Business.Pagina.BuscarPorId(id);
            ViewBag.Pagina = pagina;

            return View();
        }
    }
}