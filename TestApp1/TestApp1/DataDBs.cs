using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp1
{
    class DataDBs
    {
        public int id { get; set; }
        public string dateTime { get; set; }
        public string description { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public DataDBs() { }
        public DataDBs (string dateTime, string description, int x, int y)
        {
            this.dateTime = dateTime;
            this.description = description;
            this.x = x;
            this.y = y;
        }
    }
}
