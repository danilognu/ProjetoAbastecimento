using System.Data;

namespace ProjetoBitzen.Data
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
