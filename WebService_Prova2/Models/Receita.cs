using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService_Prova2.Models
{
    public class Receita
    {
        [Key]
        public Int32 IdReceita { get; set; }
	    public string TipoReceita { get; set; }
        public DateTime DataReceita { get; set; }
	    public Double ValorReceita { get; set; }
    }
}