using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebService_Prova2.Connect
{
    public class ConexaoPadrao : DbContext
    {
        public ConexaoPadrao() 
            : base("name=ConexaoPadrao")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<WebService_Prova2.Models.Cliente> Clientes { get; set; }
        public System.Data.Entity.DbSet<WebService_Prova2.Models.Material> Materiais { get; set; }
        public System.Data.Entity.DbSet<WebService_Prova2.Models.Aluguel> Alugueis { get; set; }
        public System.Data.Entity.DbSet<WebService_Prova2.Models.Despesa> Despesas { get; set; }
        public System.Data.Entity.DbSet<WebService_Prova2.Models.Receita> Receitas { get; set; }
        public System.Data.Entity.DbSet<WebService_Prova2.Models.Relatorio> Relatorios { get; set; }
    }
}