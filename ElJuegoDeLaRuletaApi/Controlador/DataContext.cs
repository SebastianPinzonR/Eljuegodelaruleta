using ElJuegoDeLaRuletaApi.Modelos;
using Microsoft.EntityFrameworkCore;
namespace ElJuegoDeLaRuletaApi.Controlador
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<RuletaEntity> Ruletas { get; set; }
    }
}
