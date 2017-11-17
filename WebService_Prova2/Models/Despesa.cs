using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService_Prova2.Models
{
    public class Despesa
    {
        [Key]
        public Int32 IdDespesa { get; set; }
        public string TipoDespesa { get; set; }
        public DateTime DataDespesa { get; set; }
        public Double ValorDespesa { get; set; }
    }
}