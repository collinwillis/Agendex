using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agendex.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public User(int iD, string firstName, string lastName, string email, string password, int companyId)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CompanyId = companyId;
        }

        public User()
        {
            FirstName = "AFirstName";
            LastName = "ALastName";
            Email = "AFirstAndLastName@gmail.com";
            Password = "password";
            CompanyId = 12345678;
        }
    }
}