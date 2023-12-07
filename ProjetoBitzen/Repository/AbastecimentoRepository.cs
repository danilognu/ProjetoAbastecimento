using ProjetoBitzen.Models;
using ProjetoBitzen.Data;
using ProjetoBitzen.Repository;
using System.Data;
using static Dapper.SqlMapper;
using Dapper;


namespace ProjetoBitzen.Repository
{
    public class AbastecimentoRepository: IAbastecimentoRepository
    {
        private readonly IDapperContext _context;
        public AbastecimentoRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Abastecimento>> ObterAbastecimento()
        {
            var query = @"SELECT 
                            a.Id,
                            a.VeiculoId,
                            a.MotoristaId,
                            a.TipoCombustivel,
                            a.Data,
                            a.QuantidadeAbastecida,
                            a.DataCadastroAlteracao,
                            v.Nome as NomeVeiculo,
                            m.Nome as NomeMotorista
                            FROM "+ typeof(Abastecimento).Name + @" a
                            INNER JOIN Veiculo v ON v.Id = VeiculoId
                            INNER JOIN Motorista m ON m.Id = MotoristaId ";
            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<Abastecimento>(query);
                return result.ToList();
            }
        }

        public async Task<Abastecimento> ObterAbastecimentoId(int? id)
        {
            var query = "SELECT * FROM " + typeof(Abastecimento).Name + " WHERE Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Abastecimento>(query, new { id });
                return result;
            }
        }

        public async Task Criar(Abastecimento abastecimento)
        {
            var query = "INSERT INTO " + typeof(Abastecimento).Name + @" (
                            VeiculoId,
                            MotoristaId,
                            TipoCombustivel,
                            Data,
                            QuantidadeAbastecida,
                            DataCadastroAlteracao ) VALUES 
                            (@VeiculoId,
                            @MotoristaId,
                            @TipoCombustivel,
                            @Data,
                            @QuantidadeAbastecida,
                            @DataCadastroAlteracao)";
            var parameters = new DynamicParameters();
            parameters.Add("VeiculoId", abastecimento.VeiculoId, DbType.Int32);
            parameters.Add("MotoristaId", abastecimento.MotoristaId, DbType.Int32);
            parameters.Add("TipoCombustivel", abastecimento.TipoCombustivel, DbType.String);
            parameters.Add("Data", abastecimento.Data, DbType.DateTime);
            parameters.Add("QuantidadeAbastecida", abastecimento.QuantidadeAbastecida, DbType.Decimal);
            parameters.Add("DataCadastroAlteracao", abastecimento.DataCadastroAlteracao, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Atualizar(Abastecimento abastecimento)
        {
            var query = "UPDATE " + typeof(Veiculo).Name + @" SET VeiculoId = @VeiculoId,
                            MotoristaId = @MotoristaId,
                            TipoCombustivel = @TipoCombustivel,
                            Data = @Data,
                            QuantidadeAbastecida = @QuantidadeAbastecida,
                            DataCadastroAlteracao = @DataCadastroAlteracao
                            WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", abastecimento.Id, DbType.Int64);
            parameters.Add("VeiculoId", abastecimento.VeiculoId, DbType.Int32);
            parameters.Add("MotoristaId", abastecimento.MotoristaId, DbType.Int32);
            parameters.Add("TipoCombustivel", abastecimento.TipoCombustivel, DbType.String);
            parameters.Add("Data", abastecimento.Data, DbType.DateTime);
            parameters.Add("QuantidadeAbastecida", abastecimento.QuantidadeAbastecida, DbType.Decimal);
            parameters.Add("DataCadastroAlteracao", abastecimento.DataCadastroAlteracao, DbType.DateTime);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task Apagar(Int64 id)
        {
            var query = "DELETE FROM " + typeof(Abastecimento).Name + " WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }
    }
}
