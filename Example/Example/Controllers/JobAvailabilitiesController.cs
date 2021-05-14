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
    public class JobAvailabilitiesController : ControllerBase
    {
        private readonly JobAvailManagers _mng;

        public JobAvailabilitiesController(JobAvailManagers mng)
        {
            _mng = mng;
        }

        /// <summary>
        /// Pomocu Get metode citamo vrednosti koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost id slobodnog mesta na poslu.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i nadjen je JobAvailability sa zadatim Id ///              
        [HttpGet("{id}")]
        public ActionResult GetJobAvailibility(long id)
        {
            var result = _mng.GetJobAvailabilityByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("employeebyjob/{id}")]
        public ActionResult GetEmplOnJob(long id)
        {
            var result = _mng.Get(id);
            if (result == null)
            {
                return NotFound();

            }
            return Ok(result);
        }
        /// <summary>
        /// Pomocu Get metode citamo sve vrednosti slobodnih poslova koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost svih slobodnih poslova.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i nadjeni su svi JobAvailability. ///
        [HttpGet]
        public ActionResult GetAllJobAvailabilities()
        {
            var result = _mng.GetAll();
           
            return Ok(result);
        }

       
        /// <summary>
        /// Pomocu Post metode upisujemo nove vrednosti na server.
        /// </summary>
        /// <returns>Vraca nam vrednost slobodnog posla koji moze da preuzme zaposleni. </returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i naprvljen je novi JobAvailability sa zadatim atributima. ///
        [HttpPost]
        public ActionResult PostJobAvailability(JobAvailability jobAvailability)
        {
            var result = _mng.Post(jobAvailability);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        /// <summary>
        /// Pomocu Put metode modifikujemo vrednosti koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost modifikovanog id zaposlenog i ostalih atributa.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i modifikovan je JobAvailability sa zadatim Id i ostalim atributima ///
        [HttpPut("{id}")]
        public ActionResult PutJobAvailability(long id, JobAvailability jobAvailability)
        {
            var result = _mng.Put(id, jobAvailability);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Pomocu Delete metode brisemo zadate vrednostikoje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost da je zadati id izbrisan.</returns>
        /// Ukoliko je rezultat trazenja 0 odnosno nema vrednosti, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i izbrisan je JobAvailability sa zadatim Id///
        [HttpDelete("{id}")]
        public string DeleteJobAvail(long id)
        {
            return _mng.Delete(id);
        }

    }
}
