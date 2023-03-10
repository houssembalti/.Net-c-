using AM.ApplicationCore.config;
using AM.ApplicationCore.Domain;
using AM.infrastructure.config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.infrastructure
{
    public class AMContext :DbContext

    {
        //les annotation: [key] / required: non nullable/maxlength/minlength/Stringlength/datatype:control de saisie 
        //maxlength: int , string stream
        //Display(name="-------")  //displayname("-----")
        //range(0,10) 
        //compare("attribute_name") => les deux champs soient egaux;
        //foreignkey(" ----") :changer le nom de la column clé etrangere 

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source = (localdb)\\mssqllocaldb ; initial catalog=Balti;integrated security=true"); // on peut ajouter username and password 
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //changing table name
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            //modelBuilder.Entity<Passenger>().Property(f => f.fullname.FirstName).HasColumnName("PassengerName")
            //    .IsRequired()
            //    .HasMaxLength(50)
            //    .HasColumnType("varchar");
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<String>().HaveColumnType("varchar").HaveMaxLength(50);
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
            configurationBuilder.Properties<Double>().HavePrecision(2,3); //double becomes real auto

        }
    }
}
