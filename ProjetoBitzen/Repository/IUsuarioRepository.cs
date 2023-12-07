using ProjetoBitzen.Models;

namespace ProjetoBitzen.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuario(Usuario usuario);
    }
}
