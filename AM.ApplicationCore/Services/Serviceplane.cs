using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class Serviceplane : Service<Plane>, IservicePlane
    {
        public Serviceplane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        //class ticket missing
        /*public List<Passenger> GetPassenger(Plane plane)
        {
           return  GetById(plane.Planeid).flights.SelectMany(f=>f.Tickets)
                .select(t=>t.Passenger)
                .ToList();
            
        }*/
        public List<Flight> GetFlights(Plane plane,int n)
        {
            return GetById(plane.Planeid).flights.OrderByDescending(f => f.FlightDate).Take(n).ToList();
        }
        public Boolean IsAvailablePlane(Flight flight,int n)
        {
            int x=GetById(flight.planefk).flights.Find(f => f.FlightId == flight.FlightId).Passengers.Count();
            if (x + n <= GetById(flight.planefk).Capacity)
            {
                return true;
            }
             return false;
            
        }
        
        public void DeletePlanes()
        {
             GetAll().ToList().ForEach(p =>
            {
                if (DateTime.Now.Year - p.ManufactureDate.Year > 10)
                {
                    Delete(p);
                }

            });

        }


    }
}
