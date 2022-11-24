using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.InteropServices.ComTypes;

namespace TestApp1
{
    class ApplicationContext : DbContext
    {
        public DbSet<DataDBs> DataDBs { get; set; }
        public DbSet<EmailAddress> Email { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(): base("DefaultConnection") { }
    }
}
