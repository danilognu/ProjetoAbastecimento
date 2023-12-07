using Microsoft.EntityFrameworkCore;
using ProjetoBitzen.Models;

namespace ProjetoBitzen.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Motorista> Motoristas { get; set; }

    }
}
