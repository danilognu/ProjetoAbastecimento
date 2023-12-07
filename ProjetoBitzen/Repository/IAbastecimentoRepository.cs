using ProjetoBitzen.Models;

namespace ProjetoBitzen.Repository
{
    public interface IAbastecimentoRepository
    {
        Task<IEnumerable<Abastecimento>> ObterAbastecimento();

        Task<Abastecimento> ObterAbastecimentoId(int? id);

        Task Criar(Abastecimento abastecimento);

        Task Atualizar(Abastecimento abastecimento);

        Task Apagar(Int64 id);
    }
}
