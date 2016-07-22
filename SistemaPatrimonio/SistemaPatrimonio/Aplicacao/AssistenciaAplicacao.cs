using SistemaPatrimonio.Models;
using SistemaPatrimonio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Aplicacao
{
    public class AssistenciaAplicacao
    {

        private readonly Contexto contexto;

        public AssistenciaAplicacao()
        {
            contexto = new Contexto();
        }

        public List<Assistencia> ListarTodos()
        {
            var assistencia = new List<Assistencia>();
            const string strQuery = "SELECT * FROM assistencia order by nomeAssistencia";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);
            foreach (var row in rows)
            {
                var tempAssistencia = new Assistencia
                {
                    idAssistencia = int.Parse(!string.IsNullOrEmpty(row["idAssistencia"]) ? row["idAssistencia"] : "0"),
                    nomeAssistencia = (!string.IsNullOrEmpty(row["nomeAssistencia"]) ? row["nomeAssistencia"] : "0"),
                    cidadeAssistencia = (!string.IsNullOrEmpty(row["cidadeAssistencia"]) ? row["cidadeAssistencia"] : "0"),
                    ruaAssistencia = (!string.IsNullOrEmpty(row["ruaAssistencia"]) ? row["ruaAssistencia"] : "0"),
                    numeroAssistencia = int.Parse(!string.IsNullOrEmpty(row["numeroAssistencia"]) ? row["numeroAssistencia"] : "0"),
                    telefoneAssistencia = int.Parse(!string.IsNullOrEmpty(row["telefoneAssistencia"]) ? row["telefoneAssistencia"] : "0"),
                    emailAssistencia = (!string.IsNullOrEmpty(row["emailAssistencia"]) ? row["emailAssistencia"] : "0")


                };
                assistencia.Add(tempAssistencia);
            }
            return assistencia;
        }

        public int Inserir(Assistencia assistencia)
        {
            const string commandText = " INSERT INTO assistencia " +
                 "(nomeAssistencia,emailAssistencia,telefoneAssistencia , cidadeAssistencia, ruaAssistencia,numeroAssistencia) " +
                 "VALUES ( @nomeAssistencia,@emailAssistencia,@telefoneAssistencia , @cidadeAssistencia, @ruaAssistencia,@numeroAssistencia) ";

            var parameters = new Dictionary<string, object>
            {
                {"NomeAssistencia", assistencia.nomeAssistencia},
                {"EmailAssistencia", assistencia.emailAssistencia},
                {"TelefoneAssistencia", assistencia.telefoneAssistencia},
                {"CidadeAssistencia", assistencia.cidadeAssistencia},
                {"RuaAssistencia", assistencia.ruaAssistencia},
                {"NumeroAssistencia", assistencia.numeroAssistencia}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public int Alterar(Assistencia assistencia)
        {
            var commandText = " UPDATE assistencia SET ";
            commandText += "nomeAssistencia = @nomeAssistencia, emailAssistencia = @emailAssistencia, telefoneAssistencia = @telefoneAssistencia , cidadeAssistencia = @cidadeAssistencia, ruaAssistencia = @ruaAssistencia, numeroAssistencia = @numeroAssistencia";
            commandText += " WHERE idAssistencia = @idAssistencia ";

            var parameters = new Dictionary<string, object>
            {
                {"idAssistencia", assistencia.idAssistencia},
                {"nomeAssistencia", assistencia.nomeAssistencia},
                {"emailAssistencia", assistencia.emailAssistencia},
                {"telefoneAssistencia", assistencia.telefoneAssistencia},
                {"cidadeAssistencia", assistencia.cidadeAssistencia},
                {"ruaAssistencia", assistencia.ruaAssistencia},
                {"numeroAssistencia", assistencia.numeroAssistencia}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public int Excluir(int idAssistencia)
        {
            const string strQuery = "DELETE FROM assistencia WHERE idAssistencia = @idAssistencia";
            var parametros = new Dictionary<string, object>
            {
                {"IdAssistencia", idAssistencia}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }

        public Assistencia ListarPorId(int idAssistencia)
        {
            var assistencia = new List<Assistencia>();
            const string strQuery = "SELECT * FROM assistencia WHERE idAssistencia = @idAssistencia";
            var parametros = new Dictionary<string, object>
            {
                {"IdAssistencia", idAssistencia}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempAssistencia = new Assistencia
                {
                    idAssistencia = int.Parse(!string.IsNullOrEmpty(row["idAssistencia"]) ? row["idAssistencia"] : "0"),
                    nomeAssistencia = (!string.IsNullOrEmpty(row["nomeAssistencia"]) ? row["nomeAssistencia"] : "0"),
                    emailAssistencia = (!string.IsNullOrEmpty(row["emailAssistencia"]) ? row["emailAssistencia"] : "0"),
                    telefoneAssistencia = int.Parse(!string.IsNullOrEmpty(row["telefoneAssistencia"]) ? row["telefoneAssistencia"] : "0"),
                    cidadeAssistencia = (!string.IsNullOrEmpty(row["cidadeAssistencia"]) ? row["cidadeAssistencia"] : "0"),
                    ruaAssistencia = (!string.IsNullOrEmpty(row["ruaAssistencia"]) ? row["ruaAssistencia"] : "0"),
                    numeroAssistencia = int.Parse(!string.IsNullOrEmpty(row["numeroAssistencia"]) ? row["numeroAssistencia"] : "0")

                };
                assistencia.Add(tempAssistencia);
            }

            return assistencia.FirstOrDefault();
        }

    }
}