﻿using SistemaPatrimonio.Models;
using SistemaPatrimonio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Aplicacao
{
    public class SetorAplicacao
    {
        private readonly Contexto contexto;

        public SetorAplicacao()
        {
            contexto = new Contexto();
        }

        public List<Setor> ListarTodos()
        {
            var setor = new List<Setor>();
            const string strQuery = "SELECT * FROM setor order by nomeSetor";

            var rows = contexto.ExecutaComandoComRetorno(strQuery);
            foreach (var row in rows)
            {
                var tempSetor = new Setor
                {
                    idSetor = int.Parse(!string.IsNullOrEmpty(row["idSetor"]) ? row["idSetor"] : "0"),
                    nomeSetor = row["nomeSetor"],
                    localizacaoSetor = row["localizacaoSetor"]

                };
                setor.Add(tempSetor);
            }
            return setor;
        }

        public int Inserir(Setor setor)
        {
            const string commandText = " INSERT INTO setor " +
                 "(nomeSetor, localizacaoSetor) " +
                 "VALUES (@nomeSetor,@localizacaoSetor) ";

            var parameters = new Dictionary<string, object>
            {
                {"NomeSetor", setor.nomeSetor},
                {"LocalizacaoSetor", setor.localizacaoSetor}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }

        public int Alterar(Setor setor)
        {
            var commandText = " UPDATE setor SET ";
            commandText += "nomeSetor = @nomeSetor, localizacaoSetor = @localizacaoSetor";
            commandText += " WHERE idSetor = @idSetor ";

            var parameters = new Dictionary<string, object>
            {
                {"idSetor", setor.idSetor},
                {"nomeSetor", setor.nomeSetor},
                {"localizacaoSetor", setor.localizacaoSetor}
            };

            return contexto.ExecutaComando(commandText, parameters);
        }
        
        public int Excluir(int idSetor)
        {
            const string strQuery = "DELETE FROM setor WHERE idSetor = @idSetor";
            var parametros = new Dictionary<string, object>
            {
                {"IdSetor", idSetor}
            };

            return contexto.ExecutaComando(strQuery, parametros);
        }

        public Setor ListarPorId(int idSetor)
        {
            var setor = new List<Setor>();
            const string strQuery = "SELECT * FROM setor WHERE idSetor = @idSetor";
            var parametros = new Dictionary<string, object>
            {
                {"IdSetor", idSetor}
            };
            var rows = contexto.ExecutaComandoComRetorno(strQuery, parametros);
            foreach (var row in rows)
            {
                var tempSetor = new Setor
                {
                    idSetor = int.Parse(!string.IsNullOrEmpty(row["idSetor"]) ? row["idSetor"] : "0"),
                    nomeSetor = (!string.IsNullOrEmpty(row["nomeSetor"]) ? row["nomeSetor"] : "0"),
                    localizacaoSetor = (!string.IsNullOrEmpty(row["localizacaoSetor"]) ? row["localizacaoSetor"] : "0")

                };
                setor.Add(tempSetor);
            }

            return setor.FirstOrDefault();
        }

       
    }
}