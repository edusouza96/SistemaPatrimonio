using SistemaPatrimonio.Models;
using SistemaPatrimonio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Aplicacao
{
    public class FuncionarioAplicacao
    {
        private readonly Contexto contexto;

        public FuncionarioAplicacao()
        {
            contexto = new Contexto();
        }

        public List<Funcionario> ListarTodos()
        {
            var funcionario = new List<Funcionario>();
            const string strQuery = "SELECT * FROM funcionario order by nomeFuncionario";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);
            foreach (var row in rows)
            {
                var tempFuncionario = new Funcionario
                {
                    idFuncionario = int.Parse(!string.IsNullOrEmpty(row["idFuncionario"]) ? row["idFuncionario"] : "0"),
                    nomeFuncionario = row["nomeFuncionario"],
                    telefoneFuncionario = int.Parse(!string.IsNullOrEmpty(row["telefoneFuncionario"]) ? row["telefoneFuncionario"] : "0"),
                    emailFuncionario = row["emailFuncionario"]

                };
                funcionario.Add(tempFuncionario);
            }
            return funcionario;
        }

        public int Inserir(Funcionario funcionario)
        {
            const string commandText = " INSERT INTO funcionario " +
                 "(nomeFuncionario, telefoneFuncionario, emailFuncionario) " +
                 "VALUES (@nomeFuncionario,@telefoneFuncionario, @emailFuncionario) ";

            var parameters = new Dictionary<string, object>
            {
                {"NomeFuncionario", funcionario.nomeFuncionario},
                {"TelefoneFuncionario", funcionario.telefoneFuncionario},
                {"EmailFuncionario", funcionario.emailFuncionario}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public int Alterar(Funcionario funcionario)
        {
            return 0;
        }

        public int Excluir(int idFuncionario)
        {
            return 0;
        }

        public Funcionario ListarPorId(int idFuncionario)
        {
            var funcionario = new List<Funcionario>();
            const string strQuery = "SELECT * FROM funcionario WHERE idFuncionario = @idFuncionario";
            var parametros = new Dictionary<string, object>
            {
                {"IdFuncionario", idFuncionario}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempFuncionario = new Funcionario
                {
                    idFuncionario = int.Parse(!string.IsNullOrEmpty(row["idFuncionario"]) ? row["idFuncionario"] : "0"),
                    nomeFuncionario = (!string.IsNullOrEmpty(row["nomeFuncionario"]) ? row["nomeFuncionario"] : "0"),
                    telefoneFuncionario = int.Parse(!string.IsNullOrEmpty(row["telefoneFuncionario"]) ? row["telefoneFuncionario"] : "0"),
                    emailFuncionario = (!string.IsNullOrEmpty(row["emailFuncionario"]) ? row["emailFuncionario"] : "0")

                };
                funcionario.Add(tempFuncionario);
            }

            return funcionario.FirstOrDefault();
        }
    }
}