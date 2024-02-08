using Data.LaTavernaMenu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataSection>()
                .HasMany(section => section.Dishes) // Una sezione ha molti piatti
                .WithOne(dish => dish.Section)      // Un piatto appartiene a una sezione
                .HasForeignKey(dish => dish.Id); // Chiave esterna in DataDish per la relazione

            modelBuilder.Entity<DataDish>()
                .HasOne(dish => dish.Section) // Un piatto appartiene a una sezione
                .WithMany(section => section.Dishes) // Una sezione ha molti piatti
                .HasForeignKey(dish => dish.SectionId); // Chiave esterna in DataDish per la relazione



        }
    }
}
