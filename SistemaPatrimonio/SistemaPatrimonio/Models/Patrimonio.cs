using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Models
{
    public class Patrimonio
    {
       
        public string setorPatrimonio { get; set; }
        public string equipamentoPatrimonio { get; set; }
        public string funcionarioPatrimonio { get; set; }
        [Required(ErrorMessage = "Campo Número Patrimonio Obrigatório")]
        public int numeroPatrimonio { get; set; }

        [Required(ErrorMessage = "Campo Setor Obrigatório")]
        public int setor_idSetor { get; set; }

        [Required(ErrorMessage = "Campo Equipamento Obrigatório")]
        public int equipamento_idEquipamento { get; set; }

        [Required(ErrorMessage = "Campo Funcionário Obrigatório")]
        public int funcionario_idFuncionario { get; set; }


    }
}