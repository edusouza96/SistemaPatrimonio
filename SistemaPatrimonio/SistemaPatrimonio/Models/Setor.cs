using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Models
{
    public class Setor
    {
        public int idSetor { get; set; }

        [Required(ErrorMessage = "Campo Nome Setor Obrigatório")]
        public string nomeSetor { get; set; }

        [Required(ErrorMessage = "Campo Localização Setor Obrigatório")]
        public string localizacaoSetor { get; set; }

    }
}