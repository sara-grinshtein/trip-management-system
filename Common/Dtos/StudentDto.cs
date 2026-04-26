using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto_s
{
    public class StudentDto
    {
        public string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required string StudentClass { get; set; }
    }
}
