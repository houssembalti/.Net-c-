using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff:Passenger
    {
        public DateTime EmployeementDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency)]
        public int Salary { get; set; }

        public override void PassengerType()
        {
            Console.WriteLine("I am Staff Member");
        }

    }
}
