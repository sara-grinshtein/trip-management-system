using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Teacher
    {
        [Key]
        public string Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string TeacherClass { get; set; }

    }
}
