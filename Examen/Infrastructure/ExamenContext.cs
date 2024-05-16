using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ExamenContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                (@"Data Source=(localdb)\mssqllocaldb;
                   Initial Catalog=avocatRevisionExamen2;
                   Integrated Security=true;
                   MultipleActiveResultSets=true");
            //Activer LazyLoading
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //hedhi teb3a type detenu Zone (question 3)
           /* modelBuilder.Entity<Activite>().OwnsOne(a => a.Zone);
            modelBuilder.Entity<Reservation>().HasKey(r => new { r.packFK, r.clientFK, r.DateReservation });
            modelBuilder.ApplyConfiguration(new ClientConfig());
            base.OnModelCreating(modelBuilder);*/

            modelBuilder.Entity<Avocat>().HasOne(s=>s.Specialite).WithMany(c=>c.Avocats).HasForeignKey(s=>s.SpecialiteFK)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
