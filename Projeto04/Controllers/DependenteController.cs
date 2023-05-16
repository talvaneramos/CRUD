using Projeto04.Contracts;
using Projeto04.Entities;
using Projeto04.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Controllers
{
    public class DependenteController
    {
        private IDependenteRepository dependenteRepository;
        private IFuncionarioRepository funcionarioRepository;

        public DependenteController()
        {
            dependenteRepository = new DependenteRepository();
            funcionarioRepository = new FuncionarioRepository();
        }

        #region - CadastrarDependente
        public void CadastrarDependente()
        {
            var dependente = new Dependente();

            try
            {
                Console.Write("Nome do Dependente.........: ");
                dependente.Nome = Console.ReadLine();

                Console.Write("Data de Nascimento.........: ");
                dependente.DataNascimento = DateTime.Parse(Console.ReadLine());

                Console.Write("Id do Funcionário..........: ");
                dependente.IdFuncionario = int.Parse(Console.ReadLine());

                if (funcionarioRepository != null)
                {
                    dependenteRepository.Create(dependente);
                    Console.WriteLine("\nDependente cadastrado com sucesso. ");
                }
                else
                {
                    Console.WriteLine("\nNão foi possível realizar o cadastro do dependente. ");
                    Console.WriteLine("O Funcionário informado não foi encontrado!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
        }
        #endregion

        #region - AtualizarDependente
        public void AtualizarDependente()
        {
            try
            {
                Console.Write("Id do Dependente..........: ");
                var idDependente = int.Parse(Console.ReadLine());
                var dependente = dependenteRepository.GetById(idDependente);

                if (dependente != null)
                {
                    Console.Write("Altere no nome do Dependente....: ");
                    dependente.Nome = Console.ReadLine();

                    Console.Write("Altere a data de nascimento.....: ");
                    dependente.DataNascimento = DateTime.Parse(Console.ReadLine());

                    Console.Write("Altere o id do Funcionário..: ");
                    dependente.IdFuncionario = int.Parse(Console.ReadLine());

                    if (funcionarioRepository.GetById(dependente.IdFuncionario) != null)
                    {
                        dependenteRepository.Update(dependente);
                        Console.WriteLine("\nDependente atualizado com sucesso! ");
                    }
                    else
                    {
                        Console.WriteLine("\nNão foi possível realizar a atualização do dependente.");
                        Console.WriteLine("\nO Funcionário informado não foi encontrado!");
                    }

                }
                else
                {
                    Console.WriteLine("\nDependente não foi encontrado.");
                }
                
            }            
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
        }
        #endregion

        #region - ExcluirDependente
        public void ExcluirDependente()
        {
            try
            {
                Console.Write("Id do Dependente................: ");
                var idDependente = int.Parse(Console.ReadLine());

                var dependente = dependenteRepository.GetById(idDependente);

                if(dependente != null)
                {
                    dependenteRepository.Delete(dependente);
                    Console.Write("\nDependente excluído com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nDependente não foi encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
        }
        #endregion

        #region - ConsultarDependentes
        public void ConsultarDependentes()
        {
            try
            {
                var dependentes = dependenteRepository.GetAll();              
               
                    foreach (var item in dependentes)
                    {
                        Console.WriteLine("Id do Dependente.......: " + item.IdDependente);
                        Console.WriteLine("Nome...................: " + item.Nome);
                        Console.WriteLine("Data de nascimento.....: " + item.DataNascimento.ToString("dd/MM/yyyy"));
                        Console.WriteLine("Id do Funcionário......: " + item.IdFuncionario);
                    }              

            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
        }
        #endregion

    }
}
