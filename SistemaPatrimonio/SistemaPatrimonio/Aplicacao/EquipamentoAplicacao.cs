using SistemaPatrimonio.Models;
using SistemaPatrimonio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Aplicacao
{
    public class EquipamentoAplicacao
    {
        private readonly Contexto contexto;

        public EquipamentoAplicacao()
        {
            contexto = new Contexto();
        }

        public List<Equipamento> ListarTodos()
        {
            var equipamento = new List<Equipamento>();
            const string strQuery = "SELECT * FROM equipamento order by nomeEquipamento";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);
            foreach (var row in rows)
            {
                var tempEquipamento = new Equipamento
                {
                    idEquipamento = int.Parse(!string.IsNullOrEmpty(row["idEquipamento"]) ? row["idEquipamento"] : "0"),
                    nomeEquipamento = row["nomeEquipamento"],
                    tipoEquipamento = row["tipoEquipamento"],
                    descricaoEquipamento = row["descricaoEquipamento"]

                };
                equipamento.Add(tempEquipamento);
            }
            return equipamento;
        }

        public int Inserir(Equipamento equipamento)
        {
            const string commandText = " INSERT INTO equipamento " +
                 "(nomeEquipamento, tipoEquipamento, descricaoEquipamento) " +
                 "VALUES (@nomeEquipamento,@tipoEquipamento, @descricaoEquipamento) ";

            var parameters = new Dictionary<string, object>
            {
                {"NomeEquipamento", equipamento.nomeEquipamento},
                {"TipoEquipamento", equipamento.tipoEquipamento},
                {"DescricaoEquipamento", equipamento.descricaoEquipamento}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public int Alterar(Equipamento equipamento)
        {
            return 0;
        }

        public int Excluir(int idEquipamento)
        {
            return 0;
        }

        public Equipamento ListarPorId(int idEquipamento)
        {
            var equipamento = new List<Equipamento>();
            const string strQuery = "SELECT * FROM equipamento WHERE idEquipamento = @idEquipamento";
            var parametros = new Dictionary<string, object>
            {
                {"IdEquipamento", idEquipamento}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempEquipamento = new Equipamento
                {
                    idEquipamento = int.Parse(!string.IsNullOrEmpty(row["idEquipamento"]) ? row["idEquipamento"] : "0"),
                    nomeEquipamento = (!string.IsNullOrEmpty(row["nomeEquipamento"]) ? row["nomeEquipamento"] : "0"),
                    tipoEquipamento = (!string.IsNullOrEmpty(row["tipoEquipamento"]) ? row["tipoEquipamento"] : "0"),
                    descricaoEquipamento = (!string.IsNullOrEmpty(row["descricaoEquipamento"]) ? row["descricaoEquipamento"] : "0")

                };
                equipamento.Add(tempEquipamento);
            }

            return equipamento.FirstOrDefault();
        }
    }
}