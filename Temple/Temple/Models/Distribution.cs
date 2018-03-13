using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Temple.Models
{
    public class Distribution
    {
        public int DistributionID { get; set; }
        public int DoctorID { get; set; }
        public int PacientID { get; set; }

        public Doctor Doctor { get; set; }
        public Pacient Pacient { get; set; }
    }
}
