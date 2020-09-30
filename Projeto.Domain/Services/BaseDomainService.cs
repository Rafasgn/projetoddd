using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class BaseDomainService<T> : IBaseDomainServices<T>
        where T : class
    {
        private readonly IBaseRepository<T> repository;

        public BaseDomainService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual void Insert(T obj)
        {
            repository.Insert(obj);
        }

        public virtual void Update(T obj)
        {
            repository.Update(obj);
        }

        public virtual void Delete(T obj)
        {
            repository.Delete(obj);
        }

        public virtual List<T> GetAll()
        {
            return repository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}
