using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto.Infra.Data.Repositories
{
    public class DependenteRepository : BaseRepository<Dependente>, IDependenteRepository
    {
        private readonly DataContext dataContext;

        public DependenteRepository(DataContext dataContext): base (dataContext)
        {
            this.dataContext = dataContext;
        }

        public override List<Dependente> GetAll()
        {
            return dataContext
                .Dependente
                .Include(d => d.Funcionario)
                .ToList();
        }

        public override Dependente GetById(int id)
        {
            return dataContext
                .Dependente
                .Include(d => d.Funcionario)
                .FirstOrDefault(d => d.IdDependente == id);
        }
    }
}
