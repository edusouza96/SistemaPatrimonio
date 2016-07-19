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
    public class SetorController : Controller
    {
        private SetorAplicacao setorAplicacao;

        public SetorController()
        {
            setorAplicacao = new SetorAplicacao();
        }
        public ActionResult Index(int? page, string buscaSetor)
        {
            var lista = setorAplicacao.ListarTodos();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (!String.IsNullOrEmpty(buscaSetor))
            {
                page = 1;
                var listaBusca = lista.Where(s => s.nomeSetor.ToUpper().Contains(buscaSetor.ToUpper()));
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
        public ActionResult Cadastrar(Setor setor)
        {
            
            if (ModelState.IsValid)
            {
                setorAplicacao.Inserir(setor);
                return RedirectToAction("Index");
            }


            return View(setor);
        }

        public ActionResult Editar(int idSetor)
        {
            var setor = setorAplicacao.ListarPorId(idSetor);

            if (setor == null)
                return HttpNotFound();

            return View(setor);
        }

        [HttpPost]
        public ActionResult Editar(Setor setor)
        {
           
            if (ModelState.IsValid)
            {
                setorAplicacao.Alterar(setor);
                return RedirectToAction("Index");
            }

            return View(setor);
        }

        public ActionResult Excluir(int idSetor)
        {
            var setor = setorAplicacao.ListarPorId(idSetor);

            if (setor == null)
                return HttpNotFound();

            return View(setor);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int idSetor)
        {
            setorAplicacao.Excluir(idSetor);
            return RedirectToAction("Index");
        }
    }
}