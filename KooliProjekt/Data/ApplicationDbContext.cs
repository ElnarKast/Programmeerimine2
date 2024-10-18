using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BuildingPanels> BuildingPanels { get; set; }
        public DbSet<Building> Building { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<PanelMaterial> PanelMaterial { get; set; }
        public DbSet<Panel> Panel { get; set; }
        public DbSet<Service> Service { get; set; }
    }
}