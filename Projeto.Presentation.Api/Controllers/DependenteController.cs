using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Application.Services;

namespace Projeto.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependenteController : ControllerBase
    {
        private readonly IDependenteApplicationService dependenteApplicationService;

        public DependenteController(IDependenteApplicationService dependenteApplicationService)
        {
            this.dependenteApplicationService = dependenteApplicationService;
        }

        [HttpPost]
        public IActionResult Post(DependenteCadastroModel model)
        {
            try
            {
                dependenteApplicationService.Insert(model);
                return Ok("Dependente cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }
        [HttpPut]
        public IActionResult Put(DependenteEdicaoModel model)
        {
            try
            {
                dependenteApplicationService.Update(model);
                return Ok("Dependente Alterado  com sucesso");
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
                dependenteApplicationService.Delete(id);
                return Ok("Dependente excluido com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(dependenteApplicationService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(dependenteApplicationService.GetById(id));
        }
    }
}
