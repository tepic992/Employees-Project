using Example.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Example.Managers
{
    public class JobManagers 
    {
        private readonly FirmDbContext _context;

        public JobManagers(FirmDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Preko metode Get FindByID nalazimo posao koji zelimo da nam se prikaze.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vraca nam vrednost unetog ID za posao koji trazimo.</returns>
        public Job Get(long id)
        {
            return _context.tblJobs.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Pomocu ove metode dobijamo uvid u sve poslove.
        /// </summary>
        /// <returns>Vraca nam vrednost svih poslova na serveru koji postoje.</returns>
       public List<Job> GetAll()
        {
            return _context.tblJobs.ToList();
        }

        /// <summary>
        /// Automatski mozemo da postavimo novi posao.
        /// </summary>
        /// <param name="job"></param>
        /// <returns>Vraca nam vrednost novog unesenog posla.</returns>
        public Job Post(Job job)
        {
            var result = _context.tblJobTypes
               .Where(x => x.Id == job.JobTypeID);

            _context.tblJobs.Add(job);
            _context.SaveChanges();
            return job;
        }

        /// <summary>
        /// Pomocu ove metode modifikujemo zeljene ID za Job i JobType.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobs"></param>
        /// <returns>VVraca nam vrednost modifikovanih ID za jobtype i job.</returns>
        public Job Put(long id, Job jobs)
        {
            if (jobs.Start_Date < DateTime.Now || jobs.Start_Date > jobs.End_Date)
            {
                return null;
            }

            if (_context.tblJobTypes.Any(x=> x.Id == jobs.JobTypeID))
            {
                return null;
            }
            _context.tblJobs.Update(jobs);
            _context.SaveChanges();
            return jobs;
        }

        public Job PutJob(long id, Job jobs)
        {
            _context.tblJobs.Update(jobs);
            _context.SaveChanges();
            return jobs;
        }
        /// <summary>
        /// Brisemo zeljeni ID posla koji se nalazi na serveru.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ako posao sa ID postoji i izbrisemo ga, vratice nam vrednost True.</returns>
        public string Delete(long id)
        {
            Job job = _context.tblJobs.Where(x => x.Id == id).Single<Job>();
            if (job == null)
            {
                return "Job not exists.";
            }
            _context.tblJobs.Remove(job);
           bool result = _context.SaveChanges() == 1;
            if (!result)
            {
                return "Record has not successfully deleted.";
            }
            return "Record has successfully deleted.";
        }
    }
}
