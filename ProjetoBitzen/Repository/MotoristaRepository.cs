using ProjetoBitzen.Models;
using ProjetoBitzen.Data;
using ProjetoBitzen.Repository;
using System.Data;
using static Dapper.SqlMapper;
using Dapper;

namespace ProjetoBitzen.Persistencia
{

    public class MotoristaRepository: IMotoristaRepository
    {
        private readonly IDapperContext _context;
        public MotoristaRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Motorista>> ObterMotoristas()
        {
            var query = @"SELECT 	
                            Id,
	                        Nome,
	                        CPF,
	                        CNH,
	                        Categoria,
	                        DataNascimento,
	                        Status,
	                        DataCadastroAlteracao FROM " + typeof(Motorista).Name;
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Motorista>(query);
                return result.ToList();
            }
        }

        public async Task Criar(Motorista motorista)
        {
            var query = "INSERT INTO " + typeof(Motorista).Name + " (Nome,CPF,CNH,Categoria,DataNascimento,Status,DataCadastroAlteracao) VALUES (@Nome,@CPF,@CNH,@Categoria,@DataNascimento,@Status,@DataCadastroAlteracao)";
            DateTime DataNascimento = Convert.ToDateTime(motorista.DataNascimento);
            var parameters = new DynamicParameters();
            parameters.Add("Nome", motorista.Nome.ToUpper(), DbType.String);
            parameters.Add("CPF", motorista.CPF, DbType.String);
            parameters.Add("CNH", motorista.CNH, DbType.String);
            parameters.Add("Categoria", motorista.Categoria.ToUpper(), DbType.String);
            parameters.Add("DataNascimento", DataNascimento, DbType.DateTime);
            parameters.Add("Status", motorista.Status, DbType.Int32);
            parameters.Add("DataCadastroAlteracao", motorista.DataCadastroAlteracao, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Atualizar(Motorista motorista)
        {
            var query = "UPDATE " + typeof(Motorista).Name + " SET Nome = @Nome,CPF = @CPF,CNH = @CNH,Categoria = @Categoria,DataNascimento = @DataNascimento,Status = @Status,DataCadastroAlteracao = @DataCadastroAlteracao WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", motorista.Id, DbType.Int64);
            parameters.Add("Nome", motorista.Nome.ToUpper(), DbType.String);
            parameters.Add("CPF", motorista.CPF, DbType.String);
            parameters.Add("CNH", motorista.CNH, DbType.String);
            parameters.Add("Categoria", motorista.Categoria.ToUpper(), DbType.String);
            parameters.Add("DataNascimento", motorista.DataNascimento, DbType.DateTime);
            parameters.Add("Status", motorista.Status, DbType.Int32);
            parameters.Add("DataCadastroAlteracao", motorista.DataCadastroAlteracao, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Apagar(Int64 id)
        {
            var query = "DELETE FROM " + typeof(Motorista).Name + " WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<Motorista> ObterMotoristasId(int? id)
        {
            var query = "SELECT * FROM " + typeof(Motorista).Name + " WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Motorista>(query, new { id });
                return result;
            }
        }
    }
}
