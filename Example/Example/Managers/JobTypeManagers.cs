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
        public string Post(JobTypeDTO jobTypes)
        {
            if (_context.tblJobTypes
                .Any(x => x.Name == jobTypes.Name))
            {
                return "Name is in use.";
            }
            // 4 5 6
            // db 5 8 9

            // dodavanje liste skilova 
            List<Skill> skills = _context.tblSkills.ToList();

            // trazenje skilova koji nedostaju u bazi preko petlje
            string missingSkillsRetValue = "Skill with ";
            List<long> missingSkills = new List<long>();
            for (int i = 0; i < jobTypes.SkillIDs.Count; i++)
            {
                if (!skills.Any(x => x.Id == jobTypes.SkillIDs[i]))
                {
                    missingSkills.Add(jobTypes.SkillIDs[i]);
                    missingSkillsRetValue = missingSkillsRetValue + jobTypes.SkillIDs[i].ToString() + ",";
                }
            }

            if (missingSkills.Any())
            {
                missingSkillsRetValue = missingSkillsRetValue.Remove(missingSkillsRetValue.Length - 1);
                return $"{missingSkillsRetValue} dont exist.";
            }
             
            // validacija da ne moze da prosledi duplikate
            if (skills.Count != skills.Distinct().Count())
            {
                return "Duplicate exists.";
            }

            // dodavanje job type-a u bazu
            var addJobType = new JobType();

            addJobType.Name = jobTypes.Name;
            addJobType.Day = jobTypes.Day;
            addJobType.Mounth = jobTypes.Mounth;
            addJobType.Year = jobTypes.Year;
            addJobType.Description = jobTypes.Description;
            _context.Add(addJobType);
            _context.SaveChanges();


            // dodati skillove tog job type-a
            List<JobTypeSkill> addSkill = new List<JobTypeSkill>();
            for (int i = 0; i < jobTypes.SkillIDs.Count; i++)
            {
                JobTypeSkill skill = new JobTypeSkill();
                skill.JobTypeID = addJobType.Id;
                skill.SkillID = (int)jobTypes.SkillIDs[i];
                addSkill.Add(skill);
            }

            if(jobTypes.SkillIDs.Any())
            {
                _context.AddRange(addSkill);
                if(_context.SaveChanges() > 0)
                {
                    return "Job type and his skils are successfully added.";
                }
                else
                {
                    return "Job type and his skils are not successfully added.";
                }
            }   

            return "Job type is successfully added.";
        }

        /// <summary>
        /// Modifikujemo zeljeni ID JobType i unosimo ga na server.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobType"></param>
        /// <returns>Vraca nam vrednost da je stari ID modifikovan i promenjen.</returns>
        public string Put(long id, JobTypeDTO jobTypes)
        {
            // validacija za Name, ukoliko dodamo drugi id a ime ostane isto vratice nam vrednost da ime vec postoji i da mora se promeni
            var jobTypeName = _context.tblJobTypes.FirstOrDefault
               (x => x.Name == jobTypes.Name && x.Id != jobTypes.Id);
            if (jobTypeName != null)
            {
                return "JobType name already exists.";

            }

            List<Skill> skills = _context.tblSkills.ToList();
            string missingSkillsRetValue = "Skill with ";
            List<long> missingSkills = new List<long>();
            for (int i = 0; i < jobTypes.SkillIDs.Count; i++)
            {
                if (!skills.Any(x => x.Id == jobTypes.SkillIDs[i]))
                {
                    missingSkills.Add(jobTypes.SkillIDs[i]);
                    missingSkillsRetValue = missingSkillsRetValue + jobTypes.SkillIDs[i].ToString() + ",";
                }
            }

            if (missingSkills.Any())
            {
                missingSkillsRetValue = missingSkillsRetValue.Remove(missingSkillsRetValue.Length - 1);
                return $"{missingSkillsRetValue} dont exist.";
            }

            // validacija da ne moze da prosledi duplikate
            if (skills.Count != skills.Distinct().Count())
            {
                return "Duplicate exists.";
            }

            var result = _context.tblJobTypes
                .Where(x => x.Id == id)
                .FirstOrDefault();

            result.Name = jobTypes.Name;
            result.Day = jobTypes.Day;
            result.Mounth = jobTypes.Mounth;
            result.Year = jobTypes.Year;
            result.Description = jobTypes.Description;

            _context.tblJobTypes.Update(result);
            _context.SaveChanges();

            //var items = _context.tblJobTypeSkills
            //    .Where(x => !jobTypes.SkillIDs.Contains(x.Id));

            // setovanje i modifikovanje atributa za Skill
            var putSkills = new Skill();

            List<JobTypeSkill> skillsUser = _context.tblJobTypeSkills.Where(x => x.JobTypeID == jobTypes.Id).ToList();
            List<JobTypeSkill> skillsToAdd = new List<JobTypeSkill>();
            // petlja za modifikaciju skilova 
            for (int i = 0; i < jobTypes.SkillIDs.Count(); i++)
            {
                if (!skillsUser.Any(x => x.SkillID == jobTypes.SkillIDs[i]))
                {
                    JobTypeSkill jobSkill = new JobTypeSkill();
                    jobSkill.SkillID = (int)jobTypes.SkillIDs[i];
                    jobSkill.JobTypeID = jobTypes.Id;
                    skillsToAdd.Add(jobSkill);
                }

                List<JobTypeSkill> skillsToRemove = new List<JobTypeSkill>();
                if (skillsUser.Any(x => x.SkillID == jobTypes.SkillIDs[i]))
                {
                    JobTypeSkill jobSkillR = new JobTypeSkill();
                    jobSkillR.SkillID = (int)jobTypes.SkillIDs[i];
                    jobSkillR.JobTypeID = jobTypes.Id;
                    skillsToRemove.Remove(jobSkillR);
                }
                
            }
            return "JobType has successfully updated.";
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
