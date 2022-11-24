using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp1
{
    
    class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public User() { }
        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}
