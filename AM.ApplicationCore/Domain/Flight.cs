using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
            
        public string Destination { get; set; }
        public string Departure { get; set; }

        public DateTime FlightDate { get; set; }

        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }

        public float EstimatedDuration;
        [ForeignKey("plane")]
        public int? planefk { get; set; }
        public Plane? plane { get; set; } //clé nullable 
        public List<Passenger> Passengers { get; set; }


    }
}
