using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Entities
{
    public class JobTypeSkill
    {

        /// <summary>
        /// Primarni kljuc tabele JobTypeSkill.
        /// </summary>
        [Required(ErrorMessage = "Should not be null or empty.")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Strani klkjuc pridodat tabeli.
        /// </summary>
        [ForeignKey("JobType")]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int JobTypeID { get; set; }

        /// <summary>
        /// Strani kljuc pridodat tabeli.
        /// </summary>
        [ForeignKey("Skill")]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int SkillID { get; set; }

        /// <summary>
        /// Navigacioni property za JobType.
        /// </summary>
        public virtual JobType JobType { get; set; }

        /// <summary>
        /// Navigacioni property za Skill.
        /// </summary>
        public virtual Skill Skill { get; set; }
        
    }
}
