using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efcoreApp.Data
{
    public class CourseRegister
    {
        public int CourseRegisterId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime CourseRegisterDate { get; set; }
    }
}