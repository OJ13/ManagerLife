using Microsoft.EntityFrameworkCore;
using Models.Contas;

namespace Models.ContaDb
{
    public partial class ContaDbContext : DbContext
    {
        public ContaDbContext(DbContextOptions  options) : base(options) {  }

        public DbSet<Categoria> Categoria { get; set; } = null!;

        public DbSet<Conta> Conta { get; set; } = null!;

        // public DbSet<Itens> Itens { get; set; }

        // public DbSet<Debito> Debito { get; set; }
    }
}	