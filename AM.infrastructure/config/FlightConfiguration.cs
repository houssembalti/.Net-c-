using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.config
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("myflight");
           builder.HasKey(f => f.FlightId);
            builder.HasMany(p => p.Passengers).WithMany(p => p.Flights).UsingEntity(p => p.ToTable("table_passenger_flights"));
            //set null if u delete plane fk in flight gets null
            builder.HasOne(p => p.plane).WithMany(p => p.flights).HasForeignKey(p => p.planefk).OnDelete(DeleteBehavior.SetNull);
            
        }
    }
}
