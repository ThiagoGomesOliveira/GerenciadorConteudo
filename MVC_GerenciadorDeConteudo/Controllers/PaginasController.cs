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
        [HttpPost]
        [ValidateInput(false)]
        public void Alterar(int id)
        {
            try
            {
                var pagina = Business.Pagina.BuscarPorId(id);
                DateTime data;
                DateTime.TryParse(Request["Data"],out data);
                pagina.Id = id;
                pagina.Nome = Request["Nome"].ToString();
                pagina.Conteudo = Request["Conteudo"].ToString();
                pagina.Data = data;
                pagina.Save();
                TempData["Sucesso"] = "Alteração efetuada com sucesso!";
            }
            catch 
            {
                TempData["Erro"] = "Página não pode ser alterada";
            }
            Response.Redirect(url);
        }
        public void Excluir(int id)
        {
            try
            {
                Business.Pagina.Excluir(id);
                TempData["Sucesso"] = "Exclusão realizada com sucesso";
            }
            catch (Exception err)
            {
                TempData["Erro"] = $"Página não pode ser excluida. Erro: {err}" ;
            }
            Response.Redirect(url);
        }

        public ActionResult Preview(int id)
        {
            var pagina = Business.Pagina.BuscarPorId(id);
            ViewBag.Pagina = pagina;

            return View();
        }
    }
}