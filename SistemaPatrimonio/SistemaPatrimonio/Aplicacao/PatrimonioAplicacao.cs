using SistemaPatrimonio.Models;
using SistemaPatrimonio.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace SistemaPatrimonio.Aplicacao
{
    public class PatrimonioAplicacao
    {
        private readonly Contexto contexto;

        public PatrimonioAplicacao()
        {
            contexto = new Contexto();
        }

        public List<Patrimonio> ListarTodos()
        {
            var patrimonio = new List<Patrimonio>();
            const string strQuery = "SELECT * FROM patrimonio, setor, equipamento, funcionario where setor_idSetor = idSetor and equipamento_idEquipamento = idEquipamento and funcionario_idFuncionario = idFuncionario order by numeroPatrimonio";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);
            foreach (var row in rows)
            {
                var tempPatrimonio = new Patrimonio
                {
                    numeroPatrimonio = int.Parse(!string.IsNullOrEmpty(row["numeroPatrimonio"]) ? row["numeroPatrimonio"] : "0"),
                    setor_idSetor = int.Parse(!string.IsNullOrEmpty(row["setor_idSetor"]) ? row["setor_idSetor"] : "0"),
                    equipamento_idEquipamento = int.Parse(!string.IsNullOrEmpty(row["equipamento_idEquipamento"]) ? row["equipamento_idEquipamento"] : "0"),
                    funcionario_idFuncionario = int.Parse(!string.IsNullOrEmpty(row["funcionario_idFuncionario"]) ? row["funcionario_idFuncionario"] : "0"),
                    setorPatrimonio = (!string.IsNullOrEmpty(row["nomeSetor"]) ? row["nomeSetor"] : "0"),
                    equipamentoPatrimonio = (!string.IsNullOrEmpty(row["nomeEquipamento"]) ? row["nomeEquipamento"] : "0"),
                    funcionarioPatrimonio = (!string.IsNullOrEmpty(row["nomeFuncionario"]) ? row["nomeFuncionario"] : "0")

                };
                patrimonio.Add(tempPatrimonio);
            }

            return patrimonio;
        }

        public int Inserir(Patrimonio patrimonio)
        {
            const string commandText = " INSERT INTO patrimonio "+
                "(numeroPatrimonio,setor_idSetor, equipamento_idEquipamento, funcionario_idFuncionario) "+
                "VALUES (@numeroPatrimonio,@setor_idSetor, @equipamento_idEquipamento, @funcionario_idFuncionario) ";

            var parameters = new Dictionary<string, object>
            {
                {"NumeroPatrimonio", patrimonio.numeroPatrimonio},
                {"Setor_idSetor", patrimonio.setor_idSetor},
                {"Equipamento_idEquipamento", patrimonio.equipamento_idEquipamento},
                {"Funcionario_idFuncionario", patrimonio.funcionario_idFuncionario}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public int Alterar(Patrimonio patrimonio)
        {
            var commandText = " UPDATE patrimonio SET ";
            commandText += " setor_idSetor = @setor_idSetor, equipamento_idEquipamento = @equipamento_idEquipamento, funcionario_idFuncionario = @funcionario_idFuncionario  ";
            commandText += " WHERE numeroPatrimonio = @numeroPatrimonio ";

            var parameters = new Dictionary<string, object>
            {
                {"NumeroPatrimonio", patrimonio.numeroPatrimonio},
                {"Setor_idSetor", patrimonio.setor_idSetor},
                {"Equipamento_idEquipamento", patrimonio.equipamento_idEquipamento},
                {"Funcionario_idFuncionario", patrimonio.funcionario_idFuncionario}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

       

        public int Excluir(int numeroPatrimonio)
        {
            const string strQuery = "DELETE FROM patrimonio WHERE numeroPatrimonio = @numeroPatrimonio";
            var parametros = new Dictionary<string, object>
            {
                {"NumeroPatrimonio", numeroPatrimonio}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }

        public Patrimonio ListarPorId(int numeroPatrimonio)
        {
            var patrimonio = new List<Patrimonio>();
            const string strQuery = "SELECT * FROM patrimonio WHERE numeroPatrimonio = @numeroPatrimonio";
            var parametros = new Dictionary<string, object>
            {
                {"NumeroPatrimonio", numeroPatrimonio}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempPatrimonio = new Patrimonio
                {
                    numeroPatrimonio = int.Parse(!string.IsNullOrEmpty(row["numeroPatrimonio"]) ? row["numeroPatrimonio"] : "0"),
                    setor_idSetor = int.Parse(!string.IsNullOrEmpty(row["setor_idSetor"]) ? row["setor_idSetor"] : "0"),
                    equipamento_idEquipamento = int.Parse(!string.IsNullOrEmpty(row["equipamento_idEquipamento"]) ? row["equipamento_idEquipamento"] : "0"),
                    funcionario_idFuncionario = int.Parse(!string.IsNullOrEmpty(row["funcionario_idFuncionario"]) ? row["funcionario_idFuncionario"] : "0")

                };
                patrimonio.Add(tempPatrimonio);
            }

            return patrimonio.FirstOrDefault();
        }

        
    }
}