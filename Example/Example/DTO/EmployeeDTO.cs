using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.DTO
{
    public class EmployeeDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        public List<long> SkillIDs { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
