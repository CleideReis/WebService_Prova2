using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService_Prova2.Models
{
    public class Material
    {
        [Key]
        public Int32 IdMaterial { get; set; }
        public string Categoria { get; set; }
        public Int32 QtdeTotal { get; set; }
        public Int32 Estoque { get; set; }
    }
}