using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Location
    {

        public required string ID { get; set; }


        public required Coordinate Cordinate { get; set; }

        public DateTime Time { get; set; }

    }
}
