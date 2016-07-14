using SistemaPatrimonio.Aplicacao;
using SistemaPatrimonio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace SistemaPatrimonio.Controllers
{
    public class PatrimonioController : Controller
    {
        private PatrimonioAplicacao patrimonioAplicacao;
        private SetorAplicacao setorAplicacao;
        private EquipamentoAplicacao equipamentoAplicacao;
        private FuncionarioAplicacao funcionarioAplicacao;



        public PatrimonioController()
        {
            patrimonioAplicacao = new PatrimonioAplicacao();
            setorAplicacao = new SetorAplicacao();
            equipamentoAplicacao = new EquipamentoAplicacao();
            funcionarioAplicacao = new FuncionarioAplicacao();
        }

        public ActionResult Index(int? page,int ? buscaPatrimonio)
        {
            
            var lista = patrimonioAplicacao.ListarTodos();        

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (buscaPatrimonio > 0)
            {
                page = 1;
                var lista1 = lista.Where(s => s.numeroPatrimonio == buscaPatrimonio);
                return View(lista1.ToPagedList(pageNumber, pageSize));

            }
            else
            {
               
                return View(lista.ToPagedList(pageNumber, pageSize));
            }
            
        }

        public ActionResult Cadastrar()
        {
            var listaSetor = setorAplicacao.ListarTodos();
            var listaEquipamento = equipamentoAplicacao.ListarTodos();
            var listaFuncionario = funcionarioAplicacao.ListarTodos();

            ViewBag.setor_idSetor = new SelectList(listaSetor, "idSetor", "nomeSetor");
            ViewBag.equipamento_idEquipamento = new SelectList(listaEquipamento, "idEquipamento", "nomeEquipamento");
            ViewBag.funcionario_idFuncionario = new SelectList(listaFuncionario, "idFuncionario", "nomeFuncionario");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Patrimonio patrimonio)
        {
            if (ModelState.IsValid)
            {
                patrimonioAplicacao.Inserir(patrimonio);
                return RedirectToAction("Index");
            }
            var listaSetor = setorAplicacao.ListarTodos();
            var listaEquipamento = equipamentoAplicacao.ListarTodos();
            var listaFuncionario = funcionarioAplicacao.ListarTodos();

            ViewBag.setor_idSetor = new SelectList(listaSetor, "idSetor", "nomeSetor", patrimonio.setor_idSetor);
            ViewBag.equipamento_idEquipamento = new SelectList(listaEquipamento, "idEquipamento", "nomeEquipamento", patrimonio.equipamento_idEquipamento);
            ViewBag.funcionario_idFuncionario = new SelectList(listaFuncionario, "idFuncionario", "nomeFuncionario", patrimonio.funcionario_idFuncionario);
            return View(patrimonio);
        }

        public ActionResult Editar(int numeroPatrimonio)
        {
            var patrimonio = patrimonioAplicacao.ListarPorId(numeroPatrimonio);

            if (patrimonio == null)
                return HttpNotFound();

            var listaSetor = setorAplicacao.ListarTodos();
            var listaEquipamento = equipamentoAplicacao.ListarTodos();
            var listaFuncionario = funcionarioAplicacao.ListarTodos();

            ViewBag.setor_idSetor = new SelectList(listaSetor, "idSetor", "nomeSetor", patrimonio.setor_idSetor);
            ViewBag.equipamento_idEquipamento = new SelectList(listaEquipamento, "idEquipamento", "nomeEquipamento", patrimonio.equipamento_idEquipamento);
            ViewBag.funcionario_idFuncionario = new SelectList(listaFuncionario, "idFuncionario", "nomeFuncionario", patrimonio.funcionario_idFuncionario);

            return View(patrimonio);
        }

        [HttpPost]
        public ActionResult Editar(Patrimonio patrimonio)
        {
            if (ModelState.IsValid)
            {
                patrimonioAplicacao.Alterar(patrimonio);
                return RedirectToAction("Index");
            }
            var listaSetor = setorAplicacao.ListarTodos();
            var listaEquipamento = equipamentoAplicacao.ListarTodos();
            var listaFuncionario = funcionarioAplicacao.ListarTodos();

            ViewBag.setor_idSetor = new SelectList(listaSetor, "idSetor", "nomeSetor", patrimonio.setor_idSetor);
            ViewBag.equipamento_idEquipamento = new SelectList(listaEquipamento, "idEquipamento", "nomeEquipamento", patrimonio.equipamento_idEquipamento);
            ViewBag.funcionario_idFuncionario = new SelectList(listaFuncionario, "idFuncionario", "nomeFuncionario", patrimonio.funcionario_idFuncionario);

            return View(patrimonio);
        }

        public ActionResult Detalhe(int numeroPatrimonio)
        {
            var patrimonio = patrimonioAplicacao.ListarPorId(numeroPatrimonio);

            if (patrimonio == null)
                return HttpNotFound();

            return View(patrimonio);
        }

        public ActionResult Excluir(int numeroPatrimonio)
        {
            var patrimonio = patrimonioAplicacao.ListarPorId(numeroPatrimonio);

            if (patrimonio == null)
                return HttpNotFound();

            var setor = setorAplicacao.ListarPorId(patrimonio.setor_idSetor);
            var equipamento = equipamentoAplicacao.ListarPorId(patrimonio.equipamento_idEquipamento);
            var funcionario = funcionarioAplicacao.ListarPorId(patrimonio.funcionario_idFuncionario);

            ViewBag.setor_idSetor = setor.nomeSetor;
            ViewBag.equipamento_idEquipamento = equipamento.nomeEquipamento;
            ViewBag.funcionario_idFuncionario = funcionario.nomeFuncionario;


            return View(patrimonio);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int numeroPatrimonio)
        {
            patrimonioAplicacao.Excluir(numeroPatrimonio);
            return RedirectToAction("Index");
        }
    }
}