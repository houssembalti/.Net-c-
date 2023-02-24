using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IserviceFlight
    {
        public List<Flight> ListFlights { get; set; } = new List<Flight>();

        public List<DateTime> DateTimes (string d)
        {
            List<DateTime> list = new List<DateTime>();

            for (int i=0;i<ListFlights.Count;i++)
            {
                if (ListFlights[i].Destination == d)
                {
                    list.Add(ListFlights[i].FlightDate);
                }
            }
            return list;
        }
        public IEnumerable<DateTime> DateTimes2(string d)
        {

            foreach (Flight flight in ListFlights)
            {
                if (flight.Destination == d)
                {
                    yield return flight.FlightDate;
                }
            }
        }

      

        public void GetFlights (string filtervalue,Func<string,Flight,Boolean> func)
        {
            Func<string,Flight,Boolean> condition = null;
            foreach (var item in ListFlights)
            {
                if (condition(filtervalue,item))
                {
                    Console.WriteLine(item);
                }
            }
        }

        public IList<DateTime> GetFlightDates (string destination) {
            // var query = from f in ListFlights
            //            where f.Destination == destination
            //           select f.FlightDate;
            //return query.ToList();
            var query = ListFlights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate);
            return query.ToList();


        }

  

        public void ShowFlightDetails(Plane plane)
        {
            var query= from f in ListFlights
                where (f.plane==plane)
                       select new { f.FlightDate, f.Destination}

        }
    }
}
