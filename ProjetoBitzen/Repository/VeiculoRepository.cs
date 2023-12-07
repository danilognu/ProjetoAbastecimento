using ProjetoBitzen.Models;
using ProjetoBitzen.Data;
using ProjetoBitzen.Repository;
using System.Data;
using static Dapper.SqlMapper;
using Dapper;


namespace ProjetoBitzen.Repository
{
    public class VeiculoRepository: IVeiculoRepository
    {
        private readonly IDapperContext _context;
        public VeiculoRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Veiculo>> ObterVeiculo()
        {
            var query = @"SELECT 	
                            Id,
	                        Nome,
	                        TipoCombustivel,
	                        Fabricante,
	                        AnoFabricacao,
	                        CapacidadeTanque,
	                        Observacao,
	                        DataCadastroAlteracao FROM " + typeof(Veiculo).Name;
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Veiculo>(query);
                return result.ToList();
            }
        }

        public async Task<Veiculo> ObterVeiculoId(int? id)
        {
            var query = "SELECT * FROM " + typeof(Veiculo).Name + " WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Veiculo>(query, new { id });
                return result;
            }
        }

        public async Task Criar(Veiculo veiculo)
        {
            var query = "INSERT INTO " + typeof(Veiculo).Name + @" (Nome,
	                        TipoCombustivel,
	                        Fabricante,
	                        AnoFabricacao,
	                        CapacidadeTanque,
	                        Observacao) VALUES 
                            (@Nome,
	                        @TipoCombustivel,
	                        @Fabricante,
	                        @AnoFabricacao,
	                        @CapacidadeTanque,
	                        @Observacao)";
            var parameters = new DynamicParameters();
            parameters.Add("Nome", veiculo.Nome.ToUpper(), DbType.String);
            parameters.Add("TipoCombustivel", veiculo.TipoCombustivel, DbType.String);
            parameters.Add("Fabricante", veiculo.Fabricante.ToUpper(), DbType.String);
            parameters.Add("AnoFabricacao", veiculo.AnoFabricacao, DbType.Int32);
            parameters.Add("CapacidadeTanque", veiculo.CapacidadeTanque, DbType.Decimal);
            parameters.Add("Observacao", veiculo.Observacao, DbType.String);
            parameters.Add("DataCadastroAlteracao", veiculo.DataCadastroAlteracao, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Atualizar(Veiculo veiculo)
        {
            var query = "UPDATE " + typeof(Veiculo).Name + @" SET Nome = @Nome,
	                        TipoCombustivel = @TipoCombustivel,
	                        Fabricante = @Fabricante,
	                        AnoFabricacao = @AnoFabricacao,
	                        CapacidadeTanque = @CapacidadeTanque,
	                        Observacao = @Observacao
                            WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", veiculo.Id, DbType.Int64);
            parameters.Add("Nome", veiculo.Nome.ToUpper(), DbType.String);
            parameters.Add("TipoCombustivel", veiculo.TipoCombustivel, DbType.String);
            parameters.Add("Fabricante", veiculo.Fabricante.ToUpper(), DbType.String);
            parameters.Add("AnoFabricacao", veiculo.AnoFabricacao, DbType.Int32);
            parameters.Add("CapacidadeTanque", veiculo.CapacidadeTanque, DbType.Decimal);
            parameters.Add("Observacao", veiculo.Observacao, DbType.String);
            parameters.Add("DataCadastroAlteracao", veiculo.DataCadastroAlteracao, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Apagar(Int64 id)
        {
            var query = "DELETE FROM " + typeof(Veiculo).Name + " WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
