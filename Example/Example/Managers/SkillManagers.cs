using Example.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Managers
{
    public class SkillManagers
    {
        private readonly FirmDbContext _context;

        public SkillManagers(FirmDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Vraca nam rezultat preko kojeg pristupamo unosu ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Skill Get(long id)
        {
            return _context.tblSkills.Where(x => x.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Vraca nam listu svih skilova koji se nalaze u tabeli Skills.
        /// </summary>
        /// <returns></returns>
        public List<Skill> GetAll()
        {

            return _context.tblSkills.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public Skill Post(Skill skill)
        {
            var validateName = _context.tblSkills.FirstOrDefault
                (x => x.Name == skill.Name);
            if (validateName != null)
            {
                ValidationResult errorMessage = new ValidationResult
                    ("Skill name already exists.", new[] { "SkillName" });
                return validateName;
            }
            else
            {
                _context.tblSkills.Where(x => x.Id == skill.Id);
                _context.tblSkills.Add(skill);
                _context.SaveChanges();
                return skill;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public Skill Put(Skill skill)
        {
            if (_context.tblSkills.Any(x => x.Id == skill.Id))
            {
                return null;
            }
                         
            var validateName = _context.tblSkills.FirstOrDefault
                (x => x.Name == skill.Name && x.Id != skill.Id);
            if (validateName != null)
            {
                ValidationResult errorMessage = new ValidationResult
                    ("Skill name already exists.", new[] {"SkillName"});
               return validateName;
            }
            else
            {
                _context.tblSkills.Update(skill);
                _context.SaveChanges();
                return skill;
            }
                       
        }

        /// <summary>
        /// Delete naredba za brisanje ID koji ne treba da postoji vise.
        /// Ukoliko je null vraca nam vrednost da skill ne postoji jer ne moze da bude null vrednost jer je ID primarni kljuc.
        /// Ukoliko unesemo postojeci ID vratice nam kao rezultat da postojeci ID  ne moze da se izbrise jer je u upotrebi.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Delete(long id)
        {
            Skill skill = _context.tblSkills.Where(x => x.Id == id).FirstOrDefault();
            
            if (skill == null)
            {
                return "Skill does not exists.";
            }

           var skillType = _context.tblJobTypeSkills
                .Where(x => x.SkillID == id)
                .ToList();
            if (skillType != null)
            {
                return "Cant be delete because its in use.";
            }

            _context.tblSkills.Remove(skill);

            bool result = _context.SaveChanges() == 1;
            if (!result)
            {
                return "Record has not successfully deleted.";
            }
            return "Record has successfully deleted.";
        }
    }
}
