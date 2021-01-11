using LocaAmigos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.Data
{
    public class BdContext : DbContext
    {
        private readonly IConfigurationRoot _configurationFile;
        private readonly string _connectionString;

        public BdContext(DbContextOptions<BdContext> options) :
            base(options)
        {
            _configurationFile = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            _connectionString = _configurationFile
                                    .GetConnectionString("DefaultConnection");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Pessoa> pessoa { get; set; }
        public DbSet<Jogos> jogos { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Movimentacoes> movimentacoes { get; set; }

    }
}
