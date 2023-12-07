using ProjetoBitzen.Models;
using ProjetoBitzen.Data;
using ProjetoBitzen.Repository;
using System.Data;
using static Dapper.SqlMapper;
using Dapper;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;

namespace ProjetoBitzen.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDapperContext _context;
        public UsuarioRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterUsuario(Usuario usuario)
        {
            string senha = GerarMD5(usuario.Senha);
            var query = "SELECT * FROM " + typeof(Usuario).Name + " WHERE Login = @Login And Senha = @Senha";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Usuario>(query);
                return result;
            }
        }


        public string GerarMD5(string valor)

        {
            MD5 md5Hasher = MD5.Create();

            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(valor));

            StringBuilder strBuilder = new StringBuilder();


            for (int i = 0; i < valorCriptografado.Length; i++)
            {
                strBuilder.Append(valorCriptografado[i].ToString("x2"));

            }
            return strBuilder.ToString();
        }
    }
}
