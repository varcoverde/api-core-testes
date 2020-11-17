using InfoverdeCore.Entities;
using Leilao.Entities;
using Leilao.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Leilao.Repositories
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Leiloeiro> Leiloeiros { get; set; }
        public virtual DbSet<Leilao.Entities.Leilao> Leiloes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Imovel> Imoveis { get; set; }
        public virtual DbSet<Imagem> Imagens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                // .UseLoggerFactory(loggerFactory)
                .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\source\victor\api-leilao\LeilaoApi\Leilao.Data\leilaodb.mdf;Integrated Security=True;Connect Timeout=30");

            // optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Usuario>(new UsuarioConfiguration());

            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Imovel>().ToTable("Imoveis");

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }




}
