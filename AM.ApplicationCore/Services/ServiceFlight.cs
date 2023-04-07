using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight :Service<Flight> ,IserviceFlight 
    {
        public List<Flight> ListFlights { get; set; } = new List<Flight>();

        public List<DateTime> DateTimes(string d)
        {
            List<DateTime> list = new List<DateTime>();

            for (int i = 0; i < ListFlights.Count; i++)
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



        public void GetFlights(string filtervalue, Func<string, Flight, Boolean> func)
        {
            Func<string, Flight, Boolean> condition = null;
            foreach (var item in ListFlights)
            {
                if (condition(filtervalue, item))
                {
                    Console.WriteLine(item);
                }
            }
        }

        public IList<DateTime> GetFlightDates(string destination) {
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
            /* var query = from f in ListFlights
                         where (f.plane == plane)
                         select new { f.FlightDate, f.Destination };

             foreach (var item in query)
             {
                 Console.WriteLine(item.Destination + " " + item.FlightDate);
             }*/

            var req = ListFlights
                .Where(f => f.plane == plane)
                .Select(f => new { f.Destination, f.FlightDate });

            foreach (var item in req)
            {
                Console.WriteLine(item.Destination + "  " + item.FlightDate);
            }
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            // var query = from f in ListFlights
            // where f.FlightDate > startDate && f.FlightDate < startDate.AddDays(7)
            //    return query.Count();
            return ListFlights
             .Where(f => f.FlightDate > startDate && (f.FlightDate - startDate).TotalDays < 7)
                .Count();

        }

        public float DurationAverage(string destination)
        {
            //  var req = ListFlights
            //    .Where(f => f.Destination == destination)
            //   .Average(f=> f.EstimatedDuration)
            //return req;

            var query = from f in ListFlights
                        where f.Destination == destination
                        select f;

            return query.Average(f => f.EstimatedDuration);



        }
        public IList<Flight> OrderedDurationFlights()
        {
            //var query = from f in ListFlights
            //          orderby f.EstimatedDuration descending
            //        select f;
            // return query.ToList();


            var query = ListFlights
               .OrderByDescending(f => f.EstimatedDuration)
               .ToList();
            return query;
        }

        public List<Traveller> SeniorTravellers(Flight flight)
        {
            var query = (from f in ListFlights
                         where f.FlightId == flight.FlightId
                         select f).Single();
            return query.Passengers
                .OfType<Traveller>().OrderBy(p => p.BirthDate).Take(3).ToList();



        }
        public IList<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req = ListFlights
                .GroupBy(f => f.Destination).ToList();

            foreach (var item in req)
            {
                Console.WriteLine("Destination: " + item.Key);
                foreach (var item2 in item)
                {
                    Console.WriteLine("Décolage :" + item2.FlightDate);
                }
            }
            return req;
        }
        Action<Plane> FlightDetailsDel;
        Func<string, float> DurationAverageDel;
        public ServiceFlight(IUnitOfWork uow):base (uow) {
            FlightDetailsDel = plane =>
            {
                var query = from f in ListFlights
                            where (f.plane == plane)
                            select new { f.FlightDate, f.Destination };

                foreach (var item in query)
                {
                    Console.WriteLine(item.Destination + " " + item.FlightDate);
                }

            };

                DurationAverageDel = destination =>
        {
            var req = ListFlights
              .Where(f => f.Destination == destination)
             .Average(f => f.EstimatedDuration);
            return req;
        };


        }


    }
}
