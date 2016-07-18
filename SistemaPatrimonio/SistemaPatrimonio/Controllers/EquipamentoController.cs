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
    public class EquipamentoController : Controller
    {
        private EquipamentoAplicacao equipamentoAplicacao;

        public EquipamentoController()
        {
            equipamentoAplicacao = new EquipamentoAplicacao();
        }

        public ActionResult Index(int? page, string buscaEquipamento)
        {
            var lista = equipamentoAplicacao.ListarTodos();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (!String.IsNullOrEmpty(buscaEquipamento))
            {
                page = 1;
                var listaBusca = lista.Where(s => s.nomeEquipamento.Contains(buscaEquipamento));
                return View(listaBusca.ToPagedList(pageNumber, pageSize));

            }
            else
            {

                return View(lista.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult Cadastrar()
        {
            List<string> tipoEquipamento = new List<string>();
            tipoEquipamento.Add("Móvel");
            tipoEquipamento.Add("Eletrodoméstico/Eletroeletronico");
            tipoEquipamento.Add("Material de Informatica");

            ViewBag.tipoEquipamento = new SelectList(tipoEquipamento);
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Equipamento equipamento)
        {
            List<string> tipoEquipamento = new List<string>();
            tipoEquipamento.Add("Móvel");
            tipoEquipamento.Add("Eletrodoméstico/Eletroeletronico");
            tipoEquipamento.Add("Material de Informatica");

            ViewBag.tipoEquipamento = new SelectList(tipoEquipamento);
            if (ModelState.IsValid)
            {
                equipamentoAplicacao.Inserir(equipamento);
                return RedirectToAction("Index");
            }
           

            return View(equipamento);
        }

        public ActionResult Editar(int idEquipamento)
        {
            var equipamento = equipamentoAplicacao.ListarPorId(idEquipamento);

            if (equipamento == null)
                return HttpNotFound();

            List<string> tipoEquipamento = new List<string>();
            tipoEquipamento.Add("Móvel");
            tipoEquipamento.Add("Eletrodoméstico/Eletroeletronico");
            tipoEquipamento.Add("Material de Informatica");

            ViewBag.tipoEquipamento = new SelectList(tipoEquipamento, equipamento.tipoEquipamento);
            return View(equipamento);
        }

        [HttpPost]
        public ActionResult Editar(Equipamento equipamento)
        {
            List<string> tipoEquipamento = new List<string>();
            tipoEquipamento.Add("Móvel");
            tipoEquipamento.Add("Eletrodoméstico/Eletroeletronico");
            tipoEquipamento.Add("Material de Informatica");

            ViewBag.tipoEquipamento = new SelectList(tipoEquipamento, equipamento.tipoEquipamento);

            if (ModelState.IsValid)
            {
                equipamentoAplicacao.Alterar(equipamento);
                return RedirectToAction("Index");
            }
            
            return View(equipamento);
        }

    }
}