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
             p.fullname.FirstName=char.ToUpper(p.fullname.FirstName[0]) + p.fullname.FirstName.Substring(1);
            p.fullname.LastName = char.ToUpper(p.fullname.LastName[0]) + p.fullname.LastName.Substring(1);

            //valeur de p change 
        }
    }
}
