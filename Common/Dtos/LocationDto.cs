using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class LocationDto
    {
        public required string ID { get; set; }
        public required CoordinateDto Longitude { get; set; }

        public required CoordinateDto Latitude { get; set; }
        public DateTime Time { get; set; } = new DateTime();
    }
}
