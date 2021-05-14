using Example.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Data
{
    public class DbInitializer
    {
        public static void Initialize(FirmDbContext context)
        {
            context.Database.EnsureCreated();

        //    if (context.Employees.Any())
        //    {
        //        return;   
        //    }

        //    var employees = new Employee[]
        //    {
        //        new Employee{Id=1, Name = "Carson", LastName = "Alexander",
        //            DateOfEmployment = DateTime.Parse("2010-09-01") },
        //        new Employee {Id=2, Name = "Meredith", LastName = "Alonso",
        //            DateOfEmployment = DateTime.Parse("2012-09-01") },
        //        new Employee {Id=3, Name = "Arturo", LastName = "Anand",
        //            DateOfEmployment = DateTime.Parse("2013-09-01") },
        //        new Employee {Id=4, Name = "Gytis", LastName = "Barzdukas",
        //            DateOfEmployment = DateTime.Parse("2012-09-01") },
        //        new Employee {Id=5, Name = "Yan", LastName = "Li",
        //            DateOfEmployment = DateTime.Parse("2012-09-01") },
        //        new Employee {Id=6, Name = "Peggy", LastName = "Justice",
        //            DateOfEmployment = DateTime.Parse("2011-09-01") },
        //        new Employee {Id=7, Name = "Laura", LastName = "Norman",
        //            DateOfEmployment = DateTime.Parse("2013-09-01") },
        //        new Employee {Id=8, Name = "Nino", LastName = "Olivetto",
        //            DateOfEmployment = DateTime.Parse("2005-09-01") }
        //    };

        //    foreach (Employee e in employees)
        //    {
        //        context.Employees.Add(e);
        //    }
        //    context.SaveChanges();


        //    var jobs = new Job[]
        //   {
        //    new Job{JobID=20,Name="QA", Start_Date=DateTime.Parse("2010-09-01"), End_Date=DateTime.Parse("2010-09-01"), Description="", JobTypeID=100},
        //    new Job{JobID=30,Name="Backhand Developer", Start_Date=DateTime.Parse("2010-09-01"), End_Date=DateTime.Parse("2010-09-01"), Description="", JobTypeID=130},
        //    new Job{JobID=40,Name="Backhand Developer", Start_Date=DateTime.Parse("2010-09-01"), End_Date=DateTime.Parse("2010-09-01"), Description="", JobTypeID=110},
        //    new Job{JobID=50,Name="Project Manager",Start_Date=DateTime.Parse("2010-09-01"), End_Date=DateTime.Parse("2010-09-01"), Description="", JobTypeID=120},
        //    new Job{JobID=60,Name="Frontend Developer",Start_Date=DateTime.Parse("2010-09-01"), End_Date=DateTime.Parse("2010-09-01"), Description="", JobTypeID=140},
        //    new Job{JobID=70,Name="QA",Start_Date=DateTime.Parse("2010-09-01"), End_Date=DateTime.Parse("2010-09-01"), Description="", JobTypeID=150},
        //    new Job{JobID=80,Name="Frontend Developer",Start_Date=DateTime.Parse("2010-09-01"), End_Date=DateTime.Parse("2010-09-01"), Description="", JobTypeID=170},
        //    new Job{JobID=90,Name="Project Manager",Start_Date=DateTime.Parse("2010-09-01"), End_Date=DateTime.Parse("2010-09-01"), Description="", JobTypeID=170},
        //    new Job{JobID=95,Name="Frontend Developer",Start_Date=DateTime.Parse("2010-09-01"), End_Date=DateTime.Parse("2010-09-01"), Description="", JobTypeID=180}
        //   };
        //    foreach (Job j in jobs)
        //    {
        //        context.Jobs.Add(j);
        //    }
        //    context.SaveChanges();

        //    var jobAvailability = new JobAvailability[]
        //    {
        //    new JobAvailability{EmployeeID=1,JobID=40,JobAvailabilityID=41},
        //    new JobAvailability{EmployeeID=1,JobID=20,JobAvailabilityID=42},
        //    new JobAvailability{EmployeeID=1,JobID=30,JobAvailabilityID=43},
        //    new JobAvailability{EmployeeID=2,JobID=80,JobAvailabilityID=44},
        //    new JobAvailability{EmployeeID=2,JobID=30,JobAvailabilityID=43},
        //    new JobAvailability{EmployeeID=3,JobID=70,JobAvailabilityID=42},
        //    new JobAvailability{EmployeeID=3,JobID=30},
        //    new JobAvailability{EmployeeID=4,JobID=60},
        //    new JobAvailability{EmployeeID=4,JobID=60,JobAvailabilityID=45},
        //    new JobAvailability{EmployeeID=5,JobID=50,JobAvailabilityID=45},
        //    new JobAvailability{EmployeeID=6,JobID=20},
        //    new JobAvailability{EmployeeID=7,JobID=80,JobAvailabilityID=46},
        //    };
        //    foreach (JobAvailability e in jobAvailability)
        //    {
        //        context.JobAvailabilities.Add(e);
        //    }
        //    context.SaveChanges();

        //    var jobType = new JobType[]
        //    {

        //    new JobType { JobTypeID =100, Name = "Web Developer", Day = 2640, Mounth =120, Year =10, Description ="Senior" },
        //    new JobType { JobTypeID =110, Name = "Database administrator", Day =1056, Mounth =48, Year =4, Description = "Medior" },
        //    new JobType { JobTypeID =120, Name = "Computer programmer", Day =2376, Mounth =108, Year =9, Description = "Senior" },
        //    new JobType { JobTypeID =130, Name = "Software application developer", Day =3168, Mounth =144, Year =12, Description = "Senior" },
        //    new JobType { JobTypeID =140, Name = "Computer system engineer", Day =792, Mounth =36, Year =3, Description = "Medior" },
        //    new JobType { JobTypeID =150, Name = "Network system administrator", Day =1056, Mounth =48, Year =4, Description = "Medior" },
        //    new JobType { JobTypeID =160, Name = "Computer programmer", Day =2904, Mounth =132, Year =11, Description = "Senior" },
        //    new JobType { JobTypeID =170, Name = "Database administrator", Day =670, Mounth =24, Year =2, Description = "Junior" },
        //    new JobType { JobTypeID =180, Name = "Web Developer", Day =380 , Mounth =13, Year =1, Description = "Junior" }
        //};


        }
    }
}
