using Example.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Entities
{
    /// <summary>
    /// Kreirana je klasa Skill.
    /// </summary>
    public class Skill
    {       

        /// <summary>
        /// Primarni kljuc klase Skill.
        /// </summary>
        [Required(ErrorMessage = "Should not be null or empty")]
        [Key]        
        public int Id { get; set; }

        /// <summary>
        /// Ime skila zaposlenog radnika koji je ujedno i unique.
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(40, MinimumLength = 2,
        ErrorMessage = "Name should be minimum 2 characters and a maximum of 40 characters")]
        [DataType(DataType.Text)]
        [Unique]
        public string Name { get; set; }
    }
}
