using Projeto04.Contracts;
using Projeto04.Controllers;
using Projeto04.Entities;
using Projeto04.Repositories;
using System;

namespace Projeto04
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCONTROLE DE FUNCIONÁRIOS E DEPENDENTES");
            try
			{
                Console.WriteLine("===========================");
                Console.WriteLine("1 - Cadastrar Funcionário");
                Console.WriteLine("2 - Atualizar Funcionário");
                Console.WriteLine("3 - Excluir Funcionário");
                Console.WriteLine("4 - Consultar Funcionários");
                Console.WriteLine("");
                Console.WriteLine("===========================");
                Console.WriteLine("");
                Console.WriteLine("5 - Cadastrar Dependente");
                Console.WriteLine("6 - Atualizar Dependente");
                Console.WriteLine("7 - Excluir Dependente");
                Console.WriteLine("8 - Consultar Dependentes");

                Console.Write("\nInforme a opção desejada: ");
                int op = int.Parse(Console.ReadLine());

                var funcionarioController = new FuncionarioController();
                var dependenteController = new DependenteController();

                switch (op)
                {
                    case 1: 
                        funcionarioController.CadastrarFuncionario();
                        break;

                        case 2:
                        funcionarioController.AtualizarFuncionario();
                        break;

                        case 3:
                        funcionarioController.ExcluirFuncionario();
                        break;

                        case 4:
                        funcionarioController.ConsultarFuncionarios();
                        break;

                        case 5:
                        dependenteController.CadastrarDependente();
                        break;

                        case 6:
                        dependenteController.AtualizarDependente();
                        break;

                        case 7:
                        dependenteController.ExcluirDependente();
                        break;

                        case 8:                        
                        dependenteController.ConsultarDependentes();                        
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida. ");
                        break;
                }
            }
			catch (Exception ex)
			{
                Console.WriteLine("\nOcorreu um erro: " + ex);
			}
            finally
            {
                Console.WriteLine("\nFim do programa! ");
            }
            Console.ReadKey();
        }
    }
}
