using SistemaPatrimonio.Models;
using SistemaPatrimonio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Aplicacao
{
    public class ManutencaoAplicacao
    {
        private readonly Contexto contexto;

        public ManutencaoAplicacao()
        {
            contexto = new Contexto();
        }

        public List<Manutencao> ListarTodos()
        {
            var manutencao = new List<Manutencao>();
            const string strQuery = "SELECT * FROM manutencao, assistencia where assistencia_idAssistencia = idAssistencia order by dataMAnutencao desc";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);
            foreach (var row in rows)
            {
                var tempManutencao = new Manutencao
                {
                    idManutencao = int.Parse(!string.IsNullOrEmpty(row["idManutencao"]) ? row["idManutencao"] : "0"),
                    dataManutencao = DateTime.Parse(row["dataManutencao"]),
                    problemaManutencao = (!string.IsNullOrEmpty(row["problemaManutencao"]) ? row["problemaManutencao"] : "0"),
                    statusManutencao = (!string.IsNullOrEmpty(row["statusManutencao"]) ? row["statusManutencao"] : "0"),
                    patrimonio_idPatrimonio = int.Parse(!string.IsNullOrEmpty(row["patrimonio_idPatrimonio"]) ? row["patrimonio_idPatrimonio"] : "0"),
                    assistenciaManutencao = (!string.IsNullOrEmpty(row["nomeAssistencia"]) ? row["nomeAssistencia"] : "0"),
                    assistencia_idAssistencia = int.Parse(!string.IsNullOrEmpty(row["assistencia_idAssistencia"]) ? row["assistencia_idAssistencia"] : "0")

                };
                manutencao.Add(tempManutencao);
            }

            return manutencao;
        }

        public int Inserir(Manutencao manutencao)
        {
            const string commandText = " INSERT INTO manutencao " +
                "(dataManutencao,problemaManutencao, statusManutencao, patrimonio_idPatrimonio, assistencia_idAssistencia) " +
                "VALUES (@dataManutencao,@problemaManutencao, @statusManutencao, @patrimonio_idPatrimonio, @assistencia_idAssistencia) ";

            var parameters = new Dictionary<string, object>
            {
                {"DataManutencao", manutencao.dataManutencao},
                {"ProblemaManutencao", manutencao.problemaManutencao},
                {"StatusManutencao", manutencao.statusManutencao},
                {"Patrimonio_idPatrimonio", manutencao.patrimonio_idPatrimonio},
                {"assistencia_idAssistencia", manutencao.assistencia_idAssistencia}

            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public int Alterar(Manutencao manutencao)
        {
            var commandText = " UPDATE manutencao SET ";
            commandText += " problemaManutencao = @problemaManutencao, statusManutencao = @statusManutencao ,assistencia_idAssistencia = @assistencia_idAssistencia ";
            commandText += " WHERE idManutencao = @idManutencao ";

            var parameters = new Dictionary<string, object>
            {
                {"IdManutencao", manutencao.idManutencao},
                
                {"ProblemaManutencao", manutencao.problemaManutencao},
                {"StatusManutencao", manutencao.statusManutencao},
                
                {"assistencia_idAssistencia", manutencao.assistencia_idAssistencia}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }



        public int Excluir(int idManutencao)
        {
            const string strQuery = "DELETE FROM manutencao WHERE idManutencao = @idManutencao";
            var parametros = new Dictionary<string, object>
            {
                {"IdManutencao", idManutencao}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }

        public Manutencao ListarPorId(int idManutencao)
        {
            var manutencao = new List<Manutencao>();
            const string strQuery = "SELECT * FROM manutencao WHERE idManutencao = @idManutencao";
            var parametros = new Dictionary<string, object>
            {
                {"IdManutencao", idManutencao}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempManutencao = new Manutencao
                {
                    idManutencao = int.Parse(!string.IsNullOrEmpty(row["idManutencao"]) ? row["idManutencao"] : "0"),
                    dataManutencao = DateTime.Parse(row["dataManutencao"]),
                    problemaManutencao = (!string.IsNullOrEmpty(row["problemaManutencao"]) ? row["problemaManutencao"] : "0"),
                    statusManutencao = (!string.IsNullOrEmpty(row["statusManutencao"]) ? row["statusManutencao"] : "0"),
                    patrimonio_idPatrimonio = int.Parse(!string.IsNullOrEmpty(row["patrimonio_idPatrimonio"]) ? row["patrimonio_idPatrimonio"] : "0"),
                    assistencia_idAssistencia = int.Parse(!string.IsNullOrEmpty(row["assistencia_idAssistencia"]) ? row["assistencia_idAssistencia"] : "0")

                };
                manutencao.Add(tempManutencao);
            }

            return manutencao.FirstOrDefault();
        }


    }
}