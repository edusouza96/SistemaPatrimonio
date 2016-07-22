using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Models
{
    public class Assistencia
    {
        public int idAssistencia { get; set; }

        [Required(ErrorMessage = "Campo Nome Assistencia é Obrigatório")]
        public string nomeAssistencia { get; set; }

        [Required(ErrorMessage = "Campo Cidade é Obrigatório")]
        public string cidadeAssistencia { get; set; }

        [Required(ErrorMessage = "Campo Rua é Obrigatório")]
        public string ruaAssistencia { get; set; }

        [Required(ErrorMessage = "Campo Nº é Obrigatório")]
        public int numeroAssistencia { get; set; }

        [Required(ErrorMessage = "Campo Telefone é Obrigatório")]
        public int telefoneAssistencia { get; set; }

        [Required(ErrorMessage = "Campo Email é Obrigatório")]
        public string emailAssistencia { get; set; }
    }
}