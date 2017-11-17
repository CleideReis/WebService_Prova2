using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService_Prova2.Models
{
    public class Relatorio
    {
        [Key]
        public Int32 IdRelatorio { get; set; }
        public Int32 IdDespesa { get; set; }
        public Int32 IdReceita { get; set; }
        public Int32 IdAluguel { get; set; }
    }
}