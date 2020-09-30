using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
           
        {

        }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Dependente> Dependente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new DependenteMap());
        }

    }
}
