using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agendex.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public string Password { get; set; }

        public Company(int iD, string companyName, string companyEmail, string password)
        {
            ID = iD;
            CompanyName = companyName;
            CompanyEmail = companyEmail;
            Password = password;
        }
        public Company()
        {
        }
    }
}