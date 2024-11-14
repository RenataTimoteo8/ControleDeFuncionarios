using ProjetoAula04.Entities;
using ProjetoAula04.Enums;
using ProjetoAula04.Repositories;
using ProjetoAula04.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Controllers
{
    /// <summary>
    /// Classe de controle para realizar os fluxos de ações de funcionário
    /// </summary>
    public class FuncionarioController
    {
        public void CadastrarFuncionario() 
        {
            Console.WriteLine("\n*** CADASTRO DE FUNCIONARIO: ****\n");

            var funcionario = new Funcionario();

            Console.WriteLine("INFORME O NOME DO FUNCIONARIO..........: ");
            funcionario.Nome = Console.ReadLine();

            Console.WriteLine("INFORME O CPF DO FUNCIONÁRIO...........: ");
            funcionario.Cpf = Console.ReadLine();

            Console.WriteLine("INFORME O SALÁRIO DO FUNCIONÁRIO.......: ");
            funcionario.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("\t(1) ESTÁGIO");
            Console.WriteLine("\t(2) CLT");
            Console.WriteLine("\t(3) TERCEIRIZADO");
            Console.WriteLine("INFORME O TIPO (1,2 OU 3..........: ");
            funcionario.Tipo = (TipoContratacao)int.Parse(Console.ReadLine());

            #region Validação dos dados do funcionário
            //instanciando a classe de validação do funcionário
            var funcionarioValidator = new FuncionarioValidator();
            //aplicando as regras de validação no objeto 'funcionario'
            var result = funcionarioValidator.Validate(funcionario);

            //verificar se o funcionário passou nas validações
            if (result.IsValid)
            {
                var funcionarioRepositoryJson = new funcionarioRepositoryJson();
                funcionarioRepositoryJson.ExportarDados(funcionario);
                //Programando para gravar no banco de dados
                Console.WriteLine("\nFUNCIONÁRIO CADASTRADO COM SUCESSO EM ARQUIVO JSON!");

                var funcionarioRepositorySql= new FuncionarioRepositorySql();
                funcionarioRepositorySql.ExportarDados(funcionario);
                //Programando para gravar no banco de dados
                Console.WriteLine("\nFUNCIONÁRIO CADASTRADO COM SUCESSO EM ARQUIVO SQL!");

            }
            else
            {
               

                Console.WriteLine("\nOCORRERAM ERROS DE VALIDAÇÃO:");
                //percorrendo todos os erros de validação encontrados
                foreach (var item in result.Errors)
                {
                    //imprimindo cada mensagem de erro de validação obtida
                    Console.WriteLine(item.ErrorMessage);
                }
            }
            #endregion

        }

    }
}
