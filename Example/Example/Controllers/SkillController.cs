using Example.Entities;
using Example.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Controllers
{
    /// <summary>
    /// Api kontroler je vrsta Restful servisa
    /// koji prihvata http zahteve i vraca odgovor. 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private readonly SkillManagers _mng;

        public SkillController(SkillManagers mng)
        {
            _mng = mng;
        }

        /// <summary>
        /// Get zahtev pomocu kojeg unosimo postojeci ID i kao rezultat nam izbacuje ID koji smo upisali.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult GetSkill(long id)
        {
            var skills = _mng.Get(id);
            if (skills == null)
            {
                return NotFound();
            }
            return Ok(skills);
        }

        /// <summary>
        /// GetAll zahteva koji nam omogucava da vidimo sve skilove koji se nalaze u firmi.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllSkills()
        {
            var skills = _mng.GetAll();
            
                return Ok(skills);
            
        }

        /// <summary>
        /// Unosimo novi Id kao i skill zbog unique Name koji je validiran u manageru
        /// da moze da i neki novi ID ima isto zvanje kao stari ID.
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostSkill(Skill skill)
        {
            
            var newSkill = _mng.Post(skill);

            if (newSkill == null)
            {
                return NotFound();
            }
            return Ok(newSkill);
        }
        
        /// <summary>
        /// Put zahtev koji omogucava modifikaciju Skilla preko ID i Name, kao i za Post metodu sadrzi unique Name
        /// za koga smo odradili validaciju da vise zaposlenih moze da ima isto zvanje skila.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="skill"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult PutSkill(long id, Skill skill)
        {
            var result = _mng.Put(skill);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        /// <summary>
        /// Delete metoda za brisanje zeljenog ID koji nam vraca rezultat da je ID izbrisan.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]

        public string Delete(long id)
        {
            return _mng.Delete(id);
        }

        }
      
    }

