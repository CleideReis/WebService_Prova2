using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService_Prova2.Models
{
    public class Cliente
    {
        [Key]
        public Int32 IdCliente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}