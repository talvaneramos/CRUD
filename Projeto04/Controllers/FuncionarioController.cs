using Projeto04.Contracts;
using Projeto04.Entities;
using Projeto04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Controllers
{
    public class FuncionarioController
    {
        private IFuncionarioRepository funcionarioRepository;

        public FuncionarioController()
        {
            funcionarioRepository = new FuncionarioRepository();
        }

        #region - Cadastrar Funcionário
        public void CadastrarFuncionario()
        {
            var funcionario = new Funcionario();

            try
            {
                Console.Write("Nome do funcionário.............: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("Salário do funcionário..........: ");
                funcionario.Salario = decimal.Parse(Console.ReadLine());

                Console.Write("Data de admissão................: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());
                
                funcionarioRepository.Create(funcionario);

                Console.WriteLine("\nFuncionário cadastrado com sucesso. ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
        }
        #endregion

        #region - Atualizar Funcionário
        public void AtualizarFuncionario()
        {
            try
            {
                Console.Write("Informe o Id do Funcionário...........: ");
                var idFuncionario = int.Parse(Console.ReadLine());

                var funcionario = funcionarioRepository.GetById(idFuncionario);

                if (funcionario != null)
                {
                    Console.Write("Altere o nome do Funcionário......: ");
                    funcionario.Nome = Console.ReadLine();

                    Console.Write("Altere salário....................: ");
                    funcionario.Salario = decimal.Parse(Console.ReadLine());

                    Console.Write("Altere a data de admissão.........: ");
                    funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                    funcionarioRepository.Update(funcionario);

                    Console.WriteLine("\nFuncionário atualizado com sucesso! ");
                }
                else
                {
                    Console.WriteLine("\nFuncionário não foi encontrado. ");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex.Message);
            }
        }
        #endregion

        #region - Excluir Funcionário
        public void ExcluirFuncionario()
        {
            Console.Write("Informe o Id do Funcionário.........: ");
            var idFuncionario = int.Parse(Console.ReadLine());

            var funcionario = funcionarioRepository.GetById(idFuncionario);

            if (funcionario != null)
            {
                funcionarioRepository.Delete(funcionario);
                Console.WriteLine("\nFuncionário excluído com sucesso! ");
            }
            else
            {
                Console.WriteLine("\nFuncionário não encontrado. ");
            }
        }
        #endregion

        #region - ConsultarFuncionários
        public void ConsultarFuncionarios()
        {
            try
            {
                var funcionarios = funcionarioRepository.GetAll();

                foreach (var item in funcionarios)
                {
                    Console.WriteLine("Id do Funcionário...........: " + item.IdFuncionario);
                    Console.WriteLine("Nome do Funcionário.........: " + item.Nome);
                    Console.WriteLine("Salário.....................: " + item.Salario.ToString("c"));
                    Console.WriteLine("Data de admissão............: " + item.DataAdmissao.ToString("dd/MM/yyyy"));
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
