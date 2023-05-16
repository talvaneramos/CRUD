using Dapper;
using Projeto04.Contracts;
using Projeto04.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProjeto04;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Create(Funcionario entity)
        {
            var query = "insert into Funcionario(Nome, Salario, DataAdmissao) "
                      + "values(@Nome, @Salario, @DataAdmissao)";

            using var connection = new SqlConnection(connectionString);
            connection.Execute(query, entity);
        }

        public void Update(Funcionario entity)
        {
            var query = "update Funcionario set Nome = @Nome, Salario = @Salario, DataAdmissao = @DataAdmissao "
                      + "where IdFuncionario = @IdFuncionario";

            using var connection = new SqlConnection(connectionString);
            connection.Execute(query, entity);           
        }

        public void Delete(Funcionario entity)
        {
            var query = "delete from Funcionario where IdFuncionario = @IdFuncionario";

            using var connection = new SqlConnection(connectionString);
            connection.Execute(query, entity);
        }

        public List<Funcionario> GetAll()
        {
            var query = "select * from Funcionario";;

            using var connection = new SqlConnection(connectionString);
            return connection.Query<Funcionario>(query).ToList();
        }

        public Funcionario GetById(int id)
        {
            var query = "select * from Funcionario where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<Funcionario>(query, new { IdFuncionario = id });
            }
        }
    }
}
