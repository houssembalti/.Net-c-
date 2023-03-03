using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;


namespace AM.ApplicationCore.Services
{
    public static class PassengerExtension
    {
        public static void UpperFullName(this Passenger p)
        {
             p.FirstName=char.ToUpper(p.FirstName[0]) + p.FirstName.Substring(1);
            p.LastName = char.ToUpper(p.LastName[0]) + p.LastName.Substring(1);

            //valeur de p change 
        }
    }
}
