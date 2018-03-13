using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temple.Models;
using Microsoft.EntityFrameworkCore;

namespace Temple.Data
{
    public class DBInitializer
    {
        public static void Initialize(TempleContext context)
        {
            context.Database.EnsureCreated();

            // Look for any pacients.
            if (context.Pacients.Any())
            {
                return; //DB has been seeded
            }


            // Populate DB with default pacients and doctors, for future use test and debug
            // Load data in array instead of List<T> to optimize performace
            var pacients = new Pacient[]
            {
                new Pacient{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new Pacient{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-08-21")}
            };
            foreach(Pacient p in pacients)
            {
                context.Pacients.Add(p);
            }
            context.SaveChanges();

            var doctors = new Doctor[]
            {
                new Doctor{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2013-05-18")}
            };
            foreach(Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }
            context.SaveChanges();

            var distributions = new Distribution[]
            {
                new Distribution{PacientID=1,DoctorID=1},
                new Distribution{PacientID=2,DoctorID=1}
            };
            foreach(Distribution dis in distributions)
            {
                context.Distributions.Add(dis);
            }
            context.SaveChanges();
        }
    }
}
