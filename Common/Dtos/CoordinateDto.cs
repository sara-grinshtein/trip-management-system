using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dtos
{
    public class CoordinateDto
    {
        public required double Degrees { get; set; }
        public required int Minutes { get; set; }
        public required double Seconds { get; set; }
    }
}
