using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Models
{
    public class Equipamento
    {
        public int idEquipamento { get; set; }

        [Required(ErrorMessage = "Campo Nome Equipamento Obrigatório")]
        public string nomeEquipamento { get; set; }

        [Required(ErrorMessage = "Campo Tipo Equipamento Obrigatório")]
        public string tipoEquipamento { get; set; }

        [Required(ErrorMessage = "Campo Descrição Equipamento Obrigatório")]
        public string descricaoEquipamento { get; set; }
    }
}
