using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Temple.Models
{
    public class Pacient
    {
        public int PacientID { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Distribution> Distributions { get; set; }
    }
}
