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
    public class ManutencaoController : Controller
    {
        private ManutencaoAplicacao manutencaoAplicacao;
        private AssistenciaAplicacao assistenciaAplicacao;

        public ManutencaoController()
        {
            manutencaoAplicacao = new ManutencaoAplicacao();
            assistenciaAplicacao = new AssistenciaAplicacao();
        }
        public ActionResult Index(int? page, int? buscaManutencao)
        {
            var lista = manutencaoAplicacao.ListarTodos();

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            if (buscaManutencao>0)
            {
                page = 1;
                var listaBusca = lista.Where(s => s.patrimonio_idPatrimonio == buscaManutencao);
                return View(listaBusca.ToPagedList(pageNumber, pageSize));

            }
            else
            {
                return View(lista.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult Cadastrar()
        {
            List<string> statusManutencao = new List<string>();
            statusManutencao.Add("Aguardando Aprovação");
            statusManutencao.Add("Em manutenção");
            statusManutencao.Add("Resolvido");
            statusManutencao.Add("Perda Total");
            ViewBag.statusManutencao = new SelectList(statusManutencao);

            var listaAssistencia= assistenciaAplicacao.ListarTodos();
            ViewBag.assistencia_idAssistencia = new SelectList(listaAssistencia, "idAssistencia", "nomeAssistencia");
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Manutencao manutencao)
        {
            List<string> statusManutencao = new List<string>();
            statusManutencao.Add("Aguardando Aprovação");
            statusManutencao.Add("Em manutenção");
            statusManutencao.Add("Resolvido");
            statusManutencao.Add("Perda Total");
            ViewBag.statusManutencao = new SelectList(statusManutencao);

            var listaAssistencia = assistenciaAplicacao.ListarTodos();
            ViewBag.assistencia_idAssistencia = new SelectList(listaAssistencia, "idAssistencia", "nomeAssistencia", manutencao.assistencia_idAssistencia);

            if (ModelState.IsValid)
            {
                if(manutencao.dataManutencao == null)
                    manutencao.dataManutencao = DateTime.Now;
                manutencaoAplicacao.Inserir(manutencao);
                return RedirectToAction("Index");
            }


            return View(manutencao);
        }

        public ActionResult Editar(int idManutencao)
        {
            var manutencao = manutencaoAplicacao.ListarPorId(idManutencao);

            if (manutencao == null)
                return HttpNotFound();

            List<string> statusManutencao = new List<string>();
            statusManutencao.Add("Aguardando Aprovação");
            statusManutencao.Add("Em manutenção");
            statusManutencao.Add("Resolvido");
            statusManutencao.Add("Perda Total");
            ViewBag.statusManutencao = new SelectList(statusManutencao, manutencao.statusManutencao);

            var listaAssistencia = assistenciaAplicacao.ListarTodos();
            ViewBag.assistencia_idAssistencia = new SelectList(listaAssistencia, "idAssistencia", "nomeAssistencia", manutencao.assistencia_idAssistencia);
            
            return View(manutencao);
        }

        [HttpPost]
        public ActionResult Editar(Manutencao manutencao)
        {
            List<string> statusManutencao = new List<string>();
            statusManutencao.Add("Aguardando Aprovação");
            statusManutencao.Add("Em Manutenção");
            statusManutencao.Add("Resolvido");
            statusManutencao.Add("Perda Total");
            ViewBag.statusManutencao = new SelectList(statusManutencao, manutencao.statusManutencao);

            var listaAssistencia = assistenciaAplicacao.ListarTodos();
            ViewBag.assistencia_idAssistencia = new SelectList(listaAssistencia, "idAssistencia", "nomeAssistencia", manutencao.assistencia_idAssistencia);
            
            if (ModelState.IsValid)
            {
                manutencaoAplicacao.Alterar(manutencao);
                return RedirectToAction("Index");
            }

            return View(manutencao);
        }

       
    }
}