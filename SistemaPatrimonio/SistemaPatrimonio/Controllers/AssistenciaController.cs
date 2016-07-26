using PagedList;
using SistemaPatrimonio.Aplicacao;
using SistemaPatrimonio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaPatrimonio.Controllers
{
    public class AssistenciaController : Controller
    {
        private AssistenciaAplicacao assistenciaAplicacao;

        public AssistenciaController()
        {
            assistenciaAplicacao = new AssistenciaAplicacao();
        }
        public ActionResult Index(int? page, string buscaAssistencia)
        {
            var lista = assistenciaAplicacao.ListarTodos();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (!String.IsNullOrEmpty(buscaAssistencia))
            {
                page = 1;
                var listaBusca = lista.Where(s => s.nomeAssistencia.ToUpper().Contains(buscaAssistencia.ToUpper()));
                return View(listaBusca.ToPagedList(pageNumber, pageSize));

            }
            else
            {
                return View(lista.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Assistencia assistencia)
        {

            if (ModelState.IsValid)
            {
                assistenciaAplicacao.Inserir(assistencia);
                TempData["aviso"] = "Registro Atualizado!";
                return RedirectToAction("Index");
            }


            return View(assistencia);
        }

        public ActionResult Editar(int idAssistencia)
        {
            var assistencia = assistenciaAplicacao.ListarPorId(idAssistencia);

            if (assistencia == null)
                return HttpNotFound();

            return View(assistencia);
        }

        [HttpPost]
        public ActionResult Editar(Assistencia assistencia)
        {

            if (ModelState.IsValid)
            {
                assistenciaAplicacao.Alterar(assistencia);
                TempData["aviso"] = "Registro Atualizado!";
                return RedirectToAction("Index");
            }

            return View(assistencia);
        }

        public ActionResult Excluir(int idAssistencia)
        {
            var assistencia = assistenciaAplicacao.ListarPorId(idAssistencia);

            if (assistencia == null)
                return HttpNotFound();

            return View(assistencia);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int idAssistencia)
        {
            assistenciaAplicacao.Excluir(idAssistencia);
            TempData["aviso"] = "Registro Atualizado!";
            return RedirectToAction("Index");
        }
    }
}