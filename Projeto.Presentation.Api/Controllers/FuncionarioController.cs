using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioApplicationService funcionarioApplicationService;

        public FuncionarioController(IFuncionarioApplicationService funcionarioApplicationService)
        {
            this.funcionarioApplicationService = funcionarioApplicationService;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioCadastroModel model)
        {
            try
            {
                funcionarioApplicationService.Insert(model);
                return Ok("Funcionario cadastrado com sucesso");
            }
            catch(Exception e )
            { 
                return StatusCode(500, e.Message);

            }

           
        }
        [HttpPut]
        public IActionResult Put(FuncionarioEdicaoModel model)
        {
            try
            {
                funcionarioApplicationService.Update(model);
                return Ok("Funcionario Alterado com sucesso com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                funcionarioApplicationService.Delete(id);
                return Ok("Funcionario excluido com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                
                return Ok(funcionarioApplicationService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(funcionarioApplicationService.GetById(id));
        }
    }
}
