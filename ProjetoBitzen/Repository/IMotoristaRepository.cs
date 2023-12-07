using Microsoft.AspNetCore.Mvc;
using ProjetoBitzen.Models;

namespace ProjetoBitzen.Repository
{
    public interface IMotoristaRepository
    {
        Task<IEnumerable<Motorista>> ObterMotoristas();

        Task<Motorista> ObterMotoristasId(int? id);

        Task Criar(Motorista motorista);

        Task Atualizar(Motorista motorista);

        Task Apagar(Int64 id);
    }
}
