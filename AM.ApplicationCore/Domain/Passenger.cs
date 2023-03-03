using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [DisplayName("Date of birth"),DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Key,StringLength(7)]
        public string Passportnumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Emailadress { get; set; }
        [MinLength(3,ErrorMessage = "les règles ne sont pas respectées"),MaxLength(25,ErrorMessage = "les règles ne sont pas respectées")]
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        [MaxLength(8),MinLength(8)]
        public  int Telnumber { get; set; }

        public List<Flight> Flights { get; set; }

        public override string? ToString()
        {
            return FirstName + ' ' + LastName ;
        }


        //public bool CheckProfile(string nom , string prenom)
        //{
        //    return (nom==FirstName && prenom==LastName);
        //}
        //public bool CheckProfile(string nom, string prenom,string email)
        //{
        //    return (nom == FirstName && prenom == LastName && email==Emailadress);

        //}
        public bool Checkprofile(string nom, string prenom, string email=null)
        {
            if (email == null)
            {
              return (nom == FirstName && prenom == LastName);

            }
            else
                return (nom == FirstName && prenom == LastName && email == Emailadress);
        }

        public virtual void  PassengerType()
        {
            Console.WriteLine("I am Passenger");
        }


    }
}
