using ProjetoBitzen.Models;

namespace ProjetoBitzen.Repository
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> ObterVeiculo();

        Task<Veiculo> ObterVeiculoId(int? id);

        Task Criar(Veiculo veiculo);

        Task Atualizar(Veiculo veiculo);

        Task Apagar(Int64 id);
    }
}
