using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Projeto.Application.Models
{
    public class FuncionarioEdicaoModel
    {
        [Required(ErrorMessage = "Por Favor Informe o Id do funcionario")]
        public string IdFuncionario { get; set; }
        [Required(ErrorMessage = "Por Favor Informe o Nome do funcionario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por Favor Informe o CPF")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Por Favor Informe a data de admissão")]
        public string DataAdmissao { get; set; }
        [Required(ErrorMessage = "Por Favor Informe o Salário")]
        public string Salario { get; set; }

    }
}
