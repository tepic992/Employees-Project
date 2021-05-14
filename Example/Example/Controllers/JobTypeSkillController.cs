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
    public class JobTypeSkillController : ControllerBase
    {
        private readonly JobTypeSkillManagers _mng;

        public JobTypeSkillController(JobTypeSkillManagers mng)
        {
            _mng = mng;
        }

        /// <summary>
        /// Pronalazimo zeljeni ID tako sto ga unesemo i rezultat je da nam izbaci JobTypeSkill sa unesenim ID-om.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult GetTypeSkill(long id)
        {
            var result = _mng.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Get metoda preko koje pronalazimo skill po jobtype ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("skillbytype/{id}")]
        public ActionResult GetSkillByType(long id)
        {
            var result = _mng.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Pomocu GetAll metode dobijamo sve vrste skilova koje postoje.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAllTypeSkills()
        {
            var result = _mng.GetAll();

            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobTypeSkill"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostJobTypeSkill(JobTypeSkill jobTypeSkill)
        {
            var result = _mng.Post(jobTypeSkill);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        /// <summary>
        /// Pomocu Put zahteva mozemo da modifikujemo postojeceg zaposlenog menjanjem ID-a ili skila koji poseduje.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobTypeSkill"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult PutJobTypeSkill(long id, JobTypeSkill jobTypeSkill)
        {
            var result = _mng.Put(id, jobTypeSkill);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        /// <summary>
        /// Pomocu Delete zahteva brisemo zaposlenog tako sto unesemo postojeci ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public string DeleteJobTypeSkill(long id)
        {
            return _mng.Delete(id);
        }
    }
}
