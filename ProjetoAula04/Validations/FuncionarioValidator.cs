using FluentValidation;
using ProjetoAula04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Validations
{
    /// <summary>
    /// Classe para validação dos dados do funcionário.
    /// </summary> 

    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        /// <summary>
        /// Método construtor para implementar as validações do funcionário
        /// 
        public FuncionarioValidator() 
        {
            //Validações do campo 'Id'
            RuleFor(f => f.Id)
                .NotEmpty().WithMessage
                      ("Por favor, informe o ID do Funcionario.");
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage
                      ("Por favor, informe o Nome do Funcionario.")
                .Length(8, 150).WithMessage
                      ("Por favor, informe o nome do funcionário de 8 a 150 caracteres.");
            //Validações do campo 'Cpf'
            RuleFor(f => f.Cpf)
                .NotEmpty().WithMessage
                ("Por favor, informe o cpf do funcionário.")
            .Matches(@"^\d{11}$").WithMessage
                ("Por favor, informe o cpf com exatamente 11 números.");

            //Validações do campo 'Salário'
            RuleFor(f => f.Salario)
                .GreaterThan(0).WithMessage
                      ("Por favor, informe o salário com valor maior do que zero.");
          
            //Validações do campo 'Tipo'
            RuleFor(f => f.Tipo)
                .IsInEnum().WithMessage
                      ("Por favor informe um Tipo de contratação válido (1,2 ou 3).");





        }



    }
}
