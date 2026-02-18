using ComicConventionManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComicConventionManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Panel> Panels { get; set; }
        public DbSet<Guest> Guests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Panel>().HasData(

                new Panel
                {
                    PanelId = 1,
                    Title = "Comic-Con International (San Diego)",
                    Description = "Comic-Con International annual convention.",
                    StartDate = new DateTime(2026, 7, 23),
                    EndDate = new DateTime(2026, 7, 26),
                    LocationName = "San Diego Convention Center",
                    GoogleMapsLink = "https://www.google.com/maps/place/San+Diego+Convention+Center/@32.7055022,-117.1626777,698m/data=!3m2!1e3!4b1!4m6!3m5!1s0x80d953574be55d8b:0x568846370a748ca5!8m2!3d32.7054977!4d-117.1601028!16zL20vMDMzdjNz?entry=ttu&g_ep=EgoyMDI2MDIxNi4wIKXMDSoASAFQAw%3D%3D"
                },

                new Panel
                {
                    PanelId = 2,
                    Title = "New York Comic Con",
                    Description = "Major east coast comic convention.",
                    StartDate = new DateTime(2026, 10, 8),
                    EndDate = new DateTime(2026, 10, 11),
                    LocationName = "Javits Center",
                    GoogleMapsLink = "https://www.google.com/maps/place/Javits+Center/@40.756884,-74.0042393,628m/data=!3m2!1e3!4b1!4m6!3m5!1s0x89c2596b0b3394a7:0x8461e42130f7d0a6!8m2!3d40.75688!4d-74.0016644!16zL20vMDdmbnJj?entry=ttu&g_ep=EgoyMDI2MDIxNi4wIKXMDSoASAFQAw%3D%3D"
                },

                new Panel
                {
                    PanelId = 3,
                    Title = "Indie Comics Creator Con (IC3)",
                    Description = "Meet rising creators and discuss indie publishing.",
                    StartDate = new DateTime(2026, 3, 9),
                    StartTime = new TimeSpan(9, 45, 0),
                    LocationName = "Room 301",
                    GoogleMapsLink = "https://www.google.com/maps/place/Southern+Connecticut+State+University/@41.3317702,-72.9509165,623m/data=!3m2!1e3!4b1!4m6!3m5!1s0x89e7d97644143fed:0x24bc80fe4793d07d!8m2!3d41.3317662!4d-72.9483416!16zL20vMDJoZHJx?entry=ttu&g_ep=EgoyMDI2MDIxNi4wIKXMDSoASAFQAw%3D%3D"
                }
            );
        }
    }
}