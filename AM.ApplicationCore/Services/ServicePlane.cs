using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Domain;
using System.Collections.Generic;
using System.Numerics;

namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }

        public bool IsAvailablePlane(Flight flight, int n)
        {           
            int capacity = Get(p=>p.Flights.Contains(flight)==true).Capacity;
            int nbPassengers =flight.Tickets.Count();
            //return ;
            return capacity>=(nbPassengers+n);
            //methode2;
            //var plane = GetAll().Where(p => p.Flights.Contains(flight) == true) 
            //    .Single();
            //var tickets = plane.Flights.Where(f => f.FlightId == flight.FlightId)
            //    .Single()
            //    .Tickets.Count();
            //return plane.Capacity - tickets > n;

            //methode 3:
           // var plane = Get(p => p.Flights.Contains(flight) == true);
            
        }

        public void DeletePlanes()
        {
            foreach (var plane in GetAll().Where(p => (DateTime.Now - p.ManufactureDate).TotalDays > 365 * 10).ToList())
            {
                Delete(plane);
                Commit();
            }
            //methode2
            //GetAll().ToList().ForEach(p =>
            //{
            //    if ( (DateTime.Now - p.ManufactureDate).TotalDays > 10*365)
            //    {
            //        Delete(p);
            //    }

            //});
            //commit();

            //methode3
            //Delete(p=>(DateTime.Now -p.ManufactureDate).TotalDays>10*365);
            //Commit();
        }

        public IList<IGrouping<int,Flight>> GetFlights(int n)
        {
           return GetAll().OrderByDescending(p=>p.PlaneId).Take(n).SelectMany(p=>p.Flights).GroupBy(f=>f.Plane.PlaneId).ToList();
        }

        public IList<Passenger> GetPassengers(Plane plane)
        {
            return GetById(plane.PlaneId).Flights.SelectMany(f=>f.Tickets.Select(t=>t.Passenger)).ToList();
        }
    }
}
