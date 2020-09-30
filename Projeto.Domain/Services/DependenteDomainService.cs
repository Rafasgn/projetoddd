using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class DependenteDomainService : BaseDomainService<Dependente>, IDependenteDomainService
    {
        private readonly IDependenteRepository dependenteRepository;
        private readonly IFuncionarioRepository funcionarioRepository;

        public DependenteDomainService(IDependenteRepository dependenteRepository, IFuncionarioRepository funcionarioRepository)
         : base(dependenteRepository)
        {
            this.dependenteRepository = dependenteRepository;
            this.funcionarioRepository = funcionarioRepository;
        }


        public override void Insert(Dependente obj)
        {
            if(Obteridade(obj.DataNascimento)>=18)
            {
                throw new Exception("Erro, O dependente deve ser menor de idade");
            }

            var qtd = funcionarioRepository.CountDependente(obj.IdFuncionario);

            if (qtd >= 3)
            {
                throw new Exception("Erro, Funcionário já possui 3 dependentes");
            }
            else
            {
                dependenteRepository.Insert(obj);
            }
        }

        public override void Update(Dependente obj)
        {
            var qtd = funcionarioRepository.CountDependente(obj.IdFuncionario);
            if (qtd >= 3)
            {
                throw new Exception("Erro, Funcionário já possui 3 dependentes");
            }
            else
            {
                dependenteRepository.Update(obj);
            }
        }


        private int Obteridade(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;
            if(DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade--;
            }

            return idade;
        }
    }
}
