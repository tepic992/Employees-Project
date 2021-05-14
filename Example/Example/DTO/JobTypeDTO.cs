using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.DTO
{
    public class JobTypeDTO
    {
        public int Id { get; set; }

        public List<long> SkillIDs { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
