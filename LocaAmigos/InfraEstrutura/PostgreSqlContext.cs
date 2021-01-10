using LocaAmigos.Models;
using Microsoft.EntityFrameworkCore;

namespace LocaAmigos.DataAccess
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> pessoa { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Jogos> jogos { get; set; }
        public DbSet<Movimentacoes> movimentacoes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
