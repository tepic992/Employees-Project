using Example.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages.Html;

namespace Example.Managers
{
    public class ManagmentManagers
    {
        private readonly FirmDbContext _context;

        public ManagmentManagers (FirmDbContext context)
        {
            _context = context;
        }

        public Manager Get(long id)
        {
           return _context.tblManagers.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Manager> GetAll()
        {
            return _context.tblManagers.ToList();
        }

        public Manager Post(Manager manager)
        {

            _context.tblManagers.Add(manager);
            _context.SaveChanges();
            return manager;
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

        public Manager Put(Manager manager)
        {
            if (_context.tblManagers.Any(x => x.Id == manager.Id))
            {
                return null;
            }

            _context.tblManagers.Update(manager);
            _context.SaveChanges();
            return manager;
        }

        public string  Delete(long id)
        {
            Manager manager = _context.tblManagers.Where(x => x.Id == id).FirstOrDefault();
            if (manager == null)
            {
                return "Manager not exists.";
            }
            
            var managerEmpl = _context.tblEmployees
                .Where(x => x.ManagerId == id)
                .ToList();
            if (managerEmpl != null)
            {
                return "Cant be deleted because its in use.";
            }
                        
            _context.tblManagers.Remove(manager);

            bool result = _context.SaveChanges() == 1;
            if (!result)
            {
                return "Record has not successfully deleted.";
            }
            return "Record has successfully deleted.";
            
        }
        
    }
}
