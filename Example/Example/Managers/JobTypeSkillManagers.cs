using Example.DTO;
using Example.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Managers
{
    public class JobTypeSkillManagers
    {
        private readonly FirmDbContext _context;

        public JobTypeSkillManagers(FirmDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Vraca nam uneseni ID koji postoji u tabeli Skills.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JobTypeSkill Get(long id)
        {
            return _context.tblJobTypeSkills.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Vraca nam listu JobType kojeg pronalazimo preko ID po skillu.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<JobTypeDTO> GetById(long id)
        {
            return _context.tblJobTypeSkills
                .Include("JobType")
                .Where(x => x.SkillID == id)
                .Select(x => new JobTypeDTO
                {
                    Id = x.JobTypeID,
                    Name = x.JobType.Name,
                    Description = x.JobType.Description
                }).OrderBy(x => x.Name).ToList();
        }

        /// <summary>
        /// Lista koja nam omogucava iscitavanje svih JobTypes, Skills i JobTypeSkills koji se nalaze u tabeli.
        /// </summary>
        /// <returns></returns>
        public List<JobTypeSkill> GetAll()
        {
            return _context.tblJobTypeSkills.ToList();
        }

        public JobTypeSkill Post(JobTypeSkill jobTypeSkill)
        {

            
            _context.tblJobTypeSkills.Add(jobTypeSkill);
            _context.SaveChanges();
            return jobTypeSkill;
        }
        
        public JobTypeSkill Put(long id, JobTypeSkill jobTypeSkill)
        {
            var result = _context.tblJobTypeSkills
                .Where(x => x.JobTypeID == id)
                .ToList();

            _context.tblJobTypeSkills.Update(jobTypeSkill);
            _context.SaveChanges();
            return jobTypeSkill;
        }

        /// <summary>
        /// Preko ID iz tabele JobTypeSkills, unosimo postojeci ID,
        /// ako ostavimo 0 vraca nam rezultat da taj ID ne postoji jer ne moze da bude null jer je primarni kljuc.
        /// Ukoliko unesemo ID koji postoji rezultat ce biti da je uspesno uklonjen.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(long id)
        {
            JobTypeSkill jobTypeSkill = _context.tblJobTypeSkills.Where(x => x.Id == id).FirstOrDefault();
            if (jobTypeSkill == null)
            {
                return "JobTypeSkill not exists";
            }

            _context.tblJobTypeSkills.Remove(jobTypeSkill);

            bool result = _context.SaveChanges() == 1;
            if (!result)
            {
                return "Record has not successfully deleted.";
            }
            return "Record has successfully deleted.";
        }
    }
}
