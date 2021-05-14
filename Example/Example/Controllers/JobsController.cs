using Example.Entities;
using Example.Managers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Example.Controllers
{
    /// <summary>
    /// Api kontroler je vrsta Restful servisa
    /// koji prihvata http zahteve i vraca odgovor. 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {

        private readonly JobManagers _mng;

        public JobsController(JobManagers mng)
        {
            _mng = mng;
        }


        /// <summary>
        /// Pomocu Get metode citamo vrednosti koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost id posla.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i nadjen je Job sa zadatim Id ///
        [HttpGet("{id}")]
       public ActionResult GetJob(long id)
        {
            var job = _mng.Get(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        /// <summary>
        /// Pomocu Get metode citamo sve poslove koji se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost svih poslova.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i nadjeni su svi poslovi. ///
        [HttpGet]
        public ActionResult GetAllJob()
        {
            var result = _mng.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Pomocu Post metode unosimo nove vrednosti na server.
        /// </summary>
        /// <returns>Vraca nam vrednost posla koji smo uneli.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i napravljen je novi posao sa id i ostalim atributima. ///
        [HttpPost]
        public ActionResult PostJob(Job job)
        {
           
            var newjob = _mng.Post(job);
            if (newjob == null)
            {
                return NotFound();
            }

            return Ok(newjob);
        }

        /// <summary>
        /// Pomocu Put metode modifikujemo vrednosti  na serveru.
        /// </summary>
        /// <returns>Vraca nam modifikovanu vrednost id posla kao i ostale atribute.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i modifikovan je posao sa zadatim Id i ostalim atributima. ///
        [HttpPut("{id}")]
       
        public ActionResult PutJob(long id, Job job)
        {
            var result = _mng.Put(id, job);

            if (id != job.Id || result == null)
            {
                return BadRequest();
            }
            return Ok(result);

        }

        /// <summary>
        /// Pomocu Delete metode brisemo vrednosti  na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost id posla koji je izbrisan.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i izbrisan je posao sa zadatim Id ///
        [HttpDelete("{id}")]
        public string DeleteJob(long id)
        {
            return _mng.Delete(id);
        }
        
    }
}


    

        
        






        
    

            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(Index => new Job
            //{
                
            //    Start_Date = DateTime.Now.AddDays(Index),
            //    End_Date = DateTime.Now.AddDays(Index),
            //    Name = Names[rng.Next(Names.Length)]

            //}).ToArray();
        
    

