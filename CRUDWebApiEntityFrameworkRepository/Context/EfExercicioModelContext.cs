using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;
using CRUDWebApiEntityFrameworkRepository.Models;


namespace CRUDWebApiEntityFrameworkRepository.Context
{
    public class EfExercicioModelContext : DbContext
    {
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Email)
                .WithOne(e => e.Pessoa)
                .HasForeignKey(e => e.Id_Pessoa)
                .HasPrincipalKey(e => e.Id);

            modelBuilder.Entity<Pessoa>()
                .HasMany(e => e.Endereco)
                .WithOne(e => e.Pessoa)
                .HasForeignKey(e => e.Id_Pessoa)
                .HasPrincipalKey(e => e.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var connectionString = configuration.GetConnectionString("StrConnection");
            builder.UseSqlServer(connectionString).UseLazyLoadingProxies()
                .ConfigureWarnings(warn => warn.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
        }
    }
}
