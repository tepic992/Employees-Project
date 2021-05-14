using Example.DTO;
using Example.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Example.Managers
{
    public class JobAvailManagers 
    {
        private readonly FirmDbContext _context;

        public JobAvailManagers(FirmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Pomocu ove metode uzimamo ID koji se nalazi na listi.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vraca nam ID koji smo uneli.</returns>
        public JobAvailability GetJobAvailabilityByID(long id)
        {
            return _context.tblJobAvailabilities.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<EmployeeDTO> Get(long id)
        {
            return _context.tblJobAvailabilities
                .Include("Employee")
                .Where(x => x.JobID == id)
                .Select(x => new EmployeeDTO
                {
                    Id = x.EmployeeID,
                    Name = x.Employee.Name,
                    LastName = x.Employee.LastName
                }).OrderBy(x => x.Name).ThenBy(x => x.LastName).ToList();

        }


        /// <summary>
        /// Pomocu ovog zahteva dobijamo sve ID koji postoje na serveru.
        /// </summary>
        /// <returns>Vraca nam listu svih poslova. </returns>
        public List<JobAvailability> GetAll()
        {
            return _context.tblJobAvailabilities.ToList();
        }

        /// <summary>
        /// Pomocu post metode unosimo ID za JobAvailability i preko JobID postavljamo ID i za zaposlenog.
        /// </summary>
        /// <param name="jobAvailability"></param>
        /// <returns>Vraca nam vrednosti koje smo upisali JobAvailability a on zatim automatski dodeljuje ID za Job i Employee.</returns>
        public JobAvailability Post(JobAvailability jobAvailability)
        {            
            _context.tblJobAvailabilities.Add(jobAvailability);
            _context.SaveChanges();
            return jobAvailability;
        }
        /// <summary>
        /// Pomocu PUT metode radimo modifikaciju ovog koda. Modigikujemo ID-S za JobAvailability, Job i Employee.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobAvailability"></param>
        /// <returns>Vraca nam vrednost modifikovanih ID za sve tri tabele.</returns>
        public JobAvailability Put(long id, JobAvailability jobAvailability)
        {
            var result = _context.tblJobAvailabilities
                .Where(x => x.EmployeeID == id)
                .ToList();
           
            _context.tblJobAvailabilities.Update(jobAvailability);
            _context.SaveChanges();
            return jobAvailability;
        }
        /// <summary>
        /// Delete metoda nam sluzi da izbrisemo zeljeni ID sa servera.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ako taj ID postoji i izbrisemo ga, vraca nam vrednost True.</returns>
        public string Delete(long id)
        {
            JobAvailability jobAvailability = _context.tblJobAvailabilities.Where(x => x.Id == id).FirstOrDefault();
            if (jobAvailability == null)
            {
                return "JobAvailability not exists.";
            }
            _context.tblJobAvailabilities.Remove(jobAvailability);
            bool result = _context.SaveChanges() == 1;
            if (!result)
            {
                return "Record has not successfully deleted.";
            }
            return "Record has successfully deleted.";
        }
    }
}
