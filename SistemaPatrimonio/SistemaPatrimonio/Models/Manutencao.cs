using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Models
{
    public class Manutencao
    {
        public string assistenciaManutencao { get; set; }
        public int idManutencao { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime ? dataManutencao { get; set; }

        [Required(ErrorMessage = "Campo Status é Obrigatório")]
        public string statusManutencao { get; set; }

        [Required(ErrorMessage = "Campo Problema é Obrigatório")]
        public string problemaManutencao { get; set; }

        [Required(ErrorMessage = "Campo Patrimonio é Obrigatório")]
        public int patrimonio_idPatrimonio { get; set; }

        [Required(ErrorMessage = "Campo Assistencia é Obrigatório")]
        public int assistencia_idAssistencia { get; set; }

        
    }
}