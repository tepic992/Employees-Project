using Example.Entities;
using Example.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Example.Controllers
{
    /// <summary>
    /// Api kontroler je vrsta Restful servisa
    /// koji prihvata http zahteve i vraca odgovor. 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmplManagers _mng;

        public EmployeesController(EmplManagers mng)
        {
            _mng = mng;
        }
        
        /// <summary>
        /// Pomocu Get metode citamo vrednosti koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost id zaposlenog.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i nadjen je zaposleni sa zadatim Id /// 
        [HttpGet("{id}")]        
        public ActionResult GetEmployee(long id)
        { 
            var employee = _mng.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        
        /// <summary>
        /// Pomocu Get metode citamo vrednosti koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost svih zaposlenih.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i nadjeni su svi zaposleni. ///
        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            var result = _mng.GetAll();
            
            return Ok(result);
        }

        [HttpGet("employeebymanager/{id}")]
        public ActionResult GetEmplManager(long id)
        {
            
            var result = _mng.Get(id);
            if (result == null)
            {
                return NotFound();

            }
            return Ok(result);
        }

        /// <summary>
        /// Pomocu Post metode upisujemo nove vrednosti koje ce se nalaziti na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost zaposlenog sa atributima.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i nadjen je zaposleni sa zadatim atributima. ///
        [HttpPost]
        public ActionResult PostEmployee(Employee employee)
        {            

            var newemployee = _mng.Post(employee);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(newemployee);
        }
                
        /// <summary>
        /// Pomocu Put metode menjamo vrednosti zaposlenog koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost zaposlenog nakopn sto smo uradili Update.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i nadjen je zaposleni sa zadatim Id ///
        [HttpPut("{id}")]
        public ActionResult PutEmployee(long id, Employee employee)
        {
            var result = _mng.Put(id, employee);

            if (id != employee.Id)
            {
                return BadRequest();
            }

            return Ok(result);

        }

        [HttpPut("managerbyemployee/{id}")]
        public ActionResult PutManagerByEmpl(long id, Employee employee)
        {
            
            var result = _mng.Put(id, employee);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Pomocu Delete metode brisemo vrednosti koje se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost id zaposlenog da je izbrisan.</returns>
        /// Ukoliko je rezultat trazenja 0, izbacice nam 404 status kod sto znaci da je doslo do greske,
        /// inace status je prihvacen i izbrisan je zaposleni sa zadatim Id ///
        [HttpDelete("{id}")]
        public string DeleteEmployee(long id)
        {            
            
            return _mng.Delete(id);
        }
        
    }
}


    
