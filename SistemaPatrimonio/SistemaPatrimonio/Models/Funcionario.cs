using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Models
{
    public class Funcionario
    {
        public int idFuncionario { get; set; }

        [Required(ErrorMessage = "Campo Nome Funcionarios Obrigatório")]
        public string nomeFuncionario { get; set; }

        [Required(ErrorMessage = "Campo Telefone Obrigatório")]
        public int telefoneFuncionario { get; set; }

        [Required(ErrorMessage = "Campo E-mail Obrigatório")]
        public string emailFuncionario { get; set; }
    }
}