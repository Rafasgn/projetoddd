using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.Models
{
    public class DependenteCadastroModel
    {
      
        [Required(ErrorMessage = "Por Favor Informe o Nome do Dependente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por Favor Informe a Data de Nascimento do Dependente")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Por Favor Informe o Id do funcionário")]
        public string IdFuncionario { get; set; }



    }
}
