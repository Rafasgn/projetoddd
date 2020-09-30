using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Domain.Contracts.Services;

namespace Projeto.Application.Services
{
    public class FuncionarioApplicationService : IFuncionarioApplicationService
    {
        private readonly IFuncionarioDomainService funcionarioDomainService;

        public FuncionarioApplicationService(IFuncionarioDomainService funcionarioDomainService)
        {
            this.funcionarioDomainService = funcionarioDomainService;
        }

        public void Insert(FuncionarioCadastroModel model)
        {
            var funcionario = new Funcionario();

            funcionario.Nome = model.Nome;
            funcionario.Cpf = model.Cpf;
            funcionario.DataAdmissao = DateTime.Parse(model.DataAdmissao);
            funcionario.Salario = int.Parse(model.Salario);
            funcionarioDomainService.Insert(funcionario);



        }

        public void Update(FuncionarioEdicaoModel model)
        {
            var funcionario = new Funcionario();

            funcionario.Nome = model.Nome;
            funcionario.Cpf = model.Cpf;
            funcionario.DataAdmissao = DateTime.Parse(model.DataAdmissao);
            funcionario.Salario = int.Parse(model.Salario);
            funcionarioDomainService.Update(funcionario);

        }

        public void Delete(int id)
        {
            var funcionario = funcionarioDomainService.GetById(id);
            if(funcionario != null)
            { funcionarioDomainService.Delete(funcionario); }
            else
            { throw new Exception("Funcionário não encontrado"); }

        }

        public List<FuncionarioConsultaModel> GetAll()
        {
            var lista = new List<FuncionarioConsultaModel>();

            //percorrer todos os dependentes obtidos no banco de dados
            foreach (var item in funcionarioDomainService.GetAll())
            {
                var model = new FuncionarioConsultaModel();

                model.IdFuncionario = item.IdFuncionario.ToString();
                model.Nome = item.Nome;
                model.Cpf = item.Cpf;
                model.DataAdmissao = item.DataAdmissao.ToString("dd/MM/yyyy");
                model.Salario = item.Salario.ToString();

                model.Dependente = new List<DependenteConsultaModel>();

                foreach(var dependente in item.Dependente)
                {
                    var modelDependente = new DependenteConsultaModel();

                    modelDependente.IdDependente = dependente.IdDependente.ToString();
                    modelDependente.Nome = dependente.Nome;
                    modelDependente.DataNascimento = dependente.DataNascimento.ToString("dd/MM/yyyy");
                    modelDependente.IdFuncionario = dependente.IdFuncionario.ToString();

                    model.Dependente.Add(modelDependente);
                }
                lista.Add(model); //adicionar na lista..
            }

            return lista;
        }

        public FuncionarioConsultaModel GetById(int id)
        { 
        //buscando um dependente baseado no id
            var funcionario = funcionarioDomainService.GetById(id);

            //verificando se o dependente foi encontrado
            if (funcionario != null)
            {
                var model = new FuncionarioConsultaModel();

                model.IdFuncionario = funcionario.IdFuncionario.ToString();
                model.Nome = funcionario.Nome;
                model.Cpf = funcionario.Cpf;
                model.DataAdmissao = funcionario.DataAdmissao.ToString("dd/MM/yyyy");
                model.Salario = funcionario.Salario.ToString();

                foreach (var dependente in funcionario.Dependente)
                {
                    var modelDependente = new DependenteConsultaModel();

                    modelDependente.IdDependente = dependente.IdDependente.ToString();
                    modelDependente.Nome = dependente.Nome;
                    modelDependente.DataNascimento = dependente.DataNascimento.ToString("dd/MM/yyyy");
                    modelDependente.IdFuncionario = dependente.IdFuncionario.ToString();

                    model.Dependente.Add(modelDependente);
                }
                return model;
            }
            else
            {
                throw new Exception("Erro! Funcionario não foi encontrado.");
}
        }
    }
}
