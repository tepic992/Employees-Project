using Example.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Example.DTO
{
    public class JobTypeDTO
    {

        [Key]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int Id { get; set; }

        public List<long> SkillIDs { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(40, MinimumLength = 2,
        ErrorMessage = "Name should be minimum 2 characters and a maximum of 40 characters")]
        [DataType(DataType.Text)]
        [Unique]
        public string Name { get; set; }

        public int Day { get; set; }

        public int Mounth { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }
    }
}
