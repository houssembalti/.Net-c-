using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    [Owned]
    public class FullName
    {
        [MinLength(3, ErrorMessage = "les règles ne sont pas respectées"), MaxLength(25, ErrorMessage = "les règles ne sont pas respectées")]
        public string FirstName { get; set; }
        [MinLength(3, ErrorMessage = "les règles ne sont pas respectées"), MaxLength(25, ErrorMessage = "les règles ne sont pas respectées")]

        public string LastName { get; set; }
        public FullName(string firstName,string lastName) {

            FirstName = firstName;
            LastName = lastName;
        }
        
    }
}
