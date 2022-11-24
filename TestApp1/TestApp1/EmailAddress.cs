using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TestApp1
{
    class EmailAddress
    {
        public int id { get; set; }
        public string email
        {
            get { return email; }
            set { email = value; }
        }

        public EmailAddress() { }
        public EmailAddress(string email) 
        {
            this.email = email;
        }
    }
}
