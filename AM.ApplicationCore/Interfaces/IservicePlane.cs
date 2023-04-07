using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IservicePlane :IService<Plane>
    {
        public List<Passenger> GetPassenger(Plane plane);
        public Boolean IsAvailablePlane(Flight flight, int n);
        public void DeletePlanes();
        public List<Flight> GetFlights(Plane plane, int n);
    }
}
