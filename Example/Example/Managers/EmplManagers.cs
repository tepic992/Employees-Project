using Example.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace Example.Managers
{
    public class EmplManagers

    {
        private readonly FirmDbContext _context;

        public EmplManagers(FirmDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Preko Get metode i FindByID nalazimo zaposlenog kojeg zelimo da nam se prikaze.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vraca nam vrednost ID zaposlenog kojeg smo uneli.</returns>
        public List<Employee> Get(long id)
        {
            return _context.tblEmployees.Where(x => x.ManagerId == id).ToList();
        }

        /// <summary>
        /// Pomocu GetAll metode dobijamo sve zaposlene koji se nalaze na serveru.
        /// </summary>
        /// <returns>Vraca nam vrednost svih unetih zaposlenih.</returns>
        public List<Employee> GetAll()
        {
                                 
            return _context.tblEmployees.ToList();
        }

        public List<Employee> GetManagedEmployees(long id)
        {
            var managedEmployees = _context.tblEmployees
                .Where(e => e.ManagerId == id)
                .ToList();

            return managedEmployees;
        }

        /// <summary>
        /// Pomocu ove metode postavljamo Employee-a.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns> Vraca nam automatski Employee.</returns>
        public Employee Post(Employee employee)
        {



            if (employee.DateOfEmployee.Date < DateTime.Now.Date)
            {
                return null;
            }

            var result = _context.tblEmployees
                .Where(x => x.Id == employee.Id);

            _context.tblEmployees.Add(employee);
            _context.SaveChanges();            
            return employee;
        }

        private  bool IsIdListValid(IEnumerable<int> idList)
        {
            idList.Any(id => !_context.tblEmployees.Any(x => x.Id == id));
            return idList.All(x => idList.Contains(x));
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {

                return false;
            }
        }

        /// <summary>
        /// Modifikujemo ID zaposlenog i ubacujemo ga u tabelu.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns>Vraca nam modifikovani ID zaposlenog.</returns>
        public Employee Put(long id, Employee employee)
        {
            if (_context.tblEmployees.Any(x => x.Id == employee.Id))
            {
                return null;
            }
          
            _context.tblEmployees.Update(employee);
            _context.SaveChanges();
            return employee;
        }
        
        /// <summary>
        /// Metoda pomocu koje izlistava Employee preko ManagerID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public List<Employee> PutManagerEmpl(long id, Employee employee)
        {
            var employeeManager = _context.tblEmployees
                .Where(x => x.ManagerId == id)
                .ToList();

            return employeeManager;
        }

        /// <summary>
        /// Preko Delete brisemo zeljeni ID zaposlenog
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ako taj ID postoji na serveru i uklonimo ga, povratna vrednost bice true.</returns>
        public string Delete(long id)
        {
            Employee employee = _context.tblEmployees.Where(x => x.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return "Employee doesnt exists.";
            }
            _context.tblEmployees.Remove(employee);

            bool result = _context.SaveChanges() == 1;
            if (!result)
            {
               return "Record has not successfully deleted.";
            }
            return "Record has successfully deleted.";
        }

    }

}

       
    

