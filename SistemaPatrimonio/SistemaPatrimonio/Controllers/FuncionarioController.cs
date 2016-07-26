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
    public class FuncionarioController : Controller
    {
        private FuncionarioAplicacao funcionarioAplicacao;

        public FuncionarioController()
        {
            funcionarioAplicacao = new FuncionarioAplicacao();
        }
        public ActionResult Index(int? page, string buscaFuncionario)
        {
            var lista = funcionarioAplicacao.ListarTodos();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (!String.IsNullOrEmpty(buscaFuncionario))
            {
                page = 1;
                var listaBusca = lista.Where(s => s.nomeFuncionario.ToUpper().Contains(buscaFuncionario.ToUpper()));
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
        public ActionResult Cadastrar(Funcionario funcionario)
        {

            if (ModelState.IsValid)
            {
                funcionarioAplicacao.Inserir(funcionario);
                TempData["aviso"] = "Registro Atualizado!";
                return RedirectToAction("Index");
            }


            return View(funcionario);
        }

        public ActionResult Editar(int idFuncionario)
        {
            var funcionario = funcionarioAplicacao.ListarPorId(idFuncionario);

            if (funcionario == null)
                return HttpNotFound();

            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Editar(Funcionario funcionario)
        {

            if (ModelState.IsValid)
            {
                funcionarioAplicacao.Alterar(funcionario);
                TempData["aviso"] = "Registro Atualizado!";
                return RedirectToAction("Index");
            }

            return View(funcionario);
        }

        public ActionResult Excluir(int idFuncionario)
        {
            var funcionario = funcionarioAplicacao.ListarPorId(idFuncionario);

            if (funcionario == null)
                return HttpNotFound();

            return View(funcionario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int idFuncionario)
        {
            funcionarioAplicacao.Excluir(idFuncionario);
            TempData["aviso"] = "Registro Atualizado!";
            return RedirectToAction("Index");
        }
    }

}