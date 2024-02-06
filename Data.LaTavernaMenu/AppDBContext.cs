using Data.LaTavernaMenu.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Data.LaTavernaMenu
{
    class AppDBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDBContext(DbContextOptions<AppDBContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Leggi la stringa di connessione dal file appsettings.json
                string connectionString = _configuration.GetConnectionString("LaTavernaMenu");

                // Configura il DbContext con la stringa di connessione
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public DbSet<DataDish> Dishes { get; set; }
        public DbSet<DataSection> Sections { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Section>().HasMany(t => t.Dishes).WithOne(f => f.);


        //    modelBuilder.Entity<Dish>()
        //        .HasKey(t => t.Id);

        //    modelBuilder.Entity<SqlError>()
        //        .HasKey(e => e.Id);

        //    modelBuilder.Entity<SqlMessage>()
        //        .HasKey(e => e.Id);

        //    modelBuilder.Entity<SqlTransaction>()
        //        .HasOne(t => t.Flusso)
        //        .WithMany(f => f.Transazioni)
        //        .HasForeignKey(t => t.CodiceFlusso)
        //        .OnDelete(DeleteBehavior.NoAction);

        //    modelBuilder.Entity<SqlError>()
        //        .HasOne(t => t.Transazione)
        //        .WithMany(f => f.Errori)
        //        .HasForeignKey(t => t.IdTransazione)
        //        .OnDelete(DeleteBehavior.NoAction);

        //    modelBuilder.Entity<SqlFiscalCodeCheck>()
        //        .HasKey(e => e.Id);

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
