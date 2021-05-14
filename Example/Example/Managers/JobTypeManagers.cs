using Example.DTO;
using Example.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;


namespace Example.Managers
{
    public class JobTypeManagers
    {
        private readonly FirmDbContext _context;

        public JobTypeManagers(FirmDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Pomocu ove metode, nalazimo zeljeni ID koji se nalazi na serveru.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vraca nam vrednost ID koji smo uneli i nasli na serveru.</returns>
        public JobType Get(long id)
        {
            return _context.tblJobTypes.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Pomocu ove metode vidimo sve JobType na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost svih JobType koji se nalaze na serveru.</returns>
        public List<JobType> GetAll()
        {
                          
            return _context.tblJobTypes.ToList();
        }

        /// <summary>
        /// Postavljamo novi ID za jobType i unosimo ga na server.
        /// </summary>
        /// <param name="jobTypes"></param>
        /// <returns>Vraca nam vrednost novog unetog JobType.</returns>
        public JobTypeDTO Post(JobTypeDTO jobTypes)
        {
            var res = _context.tblSkills
                .Where(x => jobTypes.SkillIDs.Contains(x.Id)).ToList();

            if (true)
            {

            }

            return null;
            

            
            
        }
        
        /// <summary>
        /// Modifikujemo zeljeni ID JobType i unosimo ga na server.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobType"></param>
        /// <returns>Vraca nam vrednost da je stari ID modifikovan i promenjen.</returns>
        public JobType Put(long id, JobType jobTypes)
        {


            var result = _context.tblJobs
                .Where(x => x.Id == id)
                .ToList();

            var jobTypeName = _context.tblJobTypes.FirstOrDefault
               (x => x.Name == jobTypes.Name && x.Id != jobTypes.Id);
            if (jobTypeName != null)
            {
                ValidationResult errorMessage = new ValidationResult
                    ("JobType name already exists.", new[] { "JobTypeName" });
                return jobTypeName;
            }
            else
            {
                _context.tblJobTypes.Update(jobTypes);
                _context.SaveChanges();
                return (jobTypes);
            }
           
        }

        /// <summary>
        /// Pomocu Delete metode brisemo zeljeni JobType.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vraca nam vrednost True ukoliko postoji ID i koji je izbrisan.</returns>
        public string Delete(long id)
        {
            JobType jobType = _context.tblJobTypes.Where(x => x.Id == id).FirstOrDefault();
            if (jobType == null)
            {
                return "JobType not exists.";
            }
            _context.tblJobTypes.Remove(jobType);

            bool result = _context.SaveChanges()==1;
            if (!result)
            {
                return "Record has not successfully deleted.";
            }
            return "Record has successfully deleted.";
        }

    }
}
