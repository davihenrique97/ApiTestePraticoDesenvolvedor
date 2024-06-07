using ApiTestePraticoDesenvolvedor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTestePraticoDesenvolvedor.Infra.DatabaseContext;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{

    public DbSet<ContaEntity> Conta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContaEntity>(c => c.ToTable("ContaDatabase")
        .HasKey(c => c.IdConta));

        // #TODO  DAR NOMES AOS CAMPOS
    }
}
