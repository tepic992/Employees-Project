using Example.DTO;
using Example.Entities;
using Example.Managers;
using Microsoft.AspNetCore.Mvc;


namespace Example.Controllers
{
    /// <summary>
    /// Api kontroler je vrsta Restful servisa
    /// koji prihvata http zahteve i vraca odgovor. 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class JobTypesController : ControllerBase
    {
        private readonly JobTypeManagers _mng;

        public JobTypesController(JobTypeManagers mng)
        {
            _mng = mng;
        }

        /// <summary>
        /// Pomocu Get metode citamo vrednosti koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost id vrste posla.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i nadjen je JobType sa zadatim Id ///
        [HttpGet("{id}")]
        public ActionResult GetJobTypes(long id)
        {
            var jobType = _mng.Get(id);

            if (jobType==null)
            {
                return NotFound();
            }
                return Ok(jobType);
        }

        /// <summary>
        /// Pomocu Get metode citamo sve vrednosti vrste posla koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost svih vrsta poslova.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i iscitava nam sve JobType. ///
        [HttpGet]
        public ActionResult GetAllJobTypes()
        {
            var result = _mng.GetAll();
            
                return Ok(result);
        }

        /// <summary>
        /// Pomocu Post metode upisujemo nove vrednosti koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost unesenih podataka.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i napravljen je novi JobType sa atributima ///
        [HttpPost]
        public string PostJobType(JobTypeDTO jobTypes)
        {
            var resultnew = _mng.Post(jobTypes);
            if (resultnew == null)
            {
                return _mng.Post(jobTypes);
            }
            return resultnew;
        }

        /// <summary>
        /// Pomocu Put metode modifikujemo vrednosti koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednosti id i tip posla zaposlenog.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i modifikovan je zahtev sa zadatim Id i ostalim atributima. ///
        [HttpPut("{id}")]
        public ActionResult PutJobType(long id, JobTypeDTO jobType)
        {
            var result = _mng.Put(id, jobType);
            if (result==null)
            {
                return NotFound();
            }
                return Ok(result);
           
        }

        /// <summary>
        /// Pomocu Delete metode brisemo vrednosti koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost id vrste posla koji je izbrisan.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i izbrisan je JobType sa zadatim Id ///
        [HttpDelete("{id}")]
        public string DeleteJobType(long id)
        {
            return _mng.Delete(id);
        }
    }
}
