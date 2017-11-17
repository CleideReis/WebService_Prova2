using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService_Prova2.Models
{
    public class Aluguel
    {
        [Key]
        public Int32 IdAluguel { get; set; }
        public Int32 IdCliente { get; set; }
        public Int32 IdMaterial { get; set; }
        public Int32 Quantidade { get; set; }
        public Double ValorTotal { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataDevolucao { get; set; }
      
    }
}