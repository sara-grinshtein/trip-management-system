using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Coordinate
    {

        public required int Degrees { get; set; }

        public required int Minutes { get; set; }

        public required int Seconds { get; set; }


    }
}
