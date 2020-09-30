using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Application.Models
{
    public class FuncionarioCadastroModel
    {

        [Required(ErrorMessage = "Por Favor Informe o Nome do funcionario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por Favor Informe o CPF")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Por Favor Informe a data de admissão")]
        public string  DataAdmissao { get; set; }
        [Required(ErrorMessage = "Por Favor Informe o Salário")]
        public string Salario { get; set; }
    }
}
