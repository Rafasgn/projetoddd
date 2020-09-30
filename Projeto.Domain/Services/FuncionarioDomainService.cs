using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Services
{
    public class FuncionarioDomainService : BaseDomainService<Funcionario>, IFuncionarioDomainService
    {
        private readonly IFuncionarioRepository funcionarioRepository;

        public FuncionarioDomainService(IFuncionarioRepository funcionarioRepository) : base (funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        public override void Insert(Funcionario obj)
        {
            var registro = funcionarioRepository.GetByCpf(obj.Cpf);

            if(registro != null)
            {
                throw new Exception("Erro, O cpf Já está cadastrado");

            }
            else
            {
                funcionarioRepository.Insert(obj);
            }

        }

        public override void Update(Funcionario obj)
        {
            var registro = funcionarioRepository.GetByCpf(obj.Cpf);

            if (registro != null && registro.IdFuncionario != obj.IdFuncionario)
            {
                throw new Exception("Erro, O cpf Já está cadastrado");

            }
            else
            {
                funcionarioRepository.Update(obj);
            }
        }

    }
}
