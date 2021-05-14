using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Entities
{
    /// <summary>
    /// Kreirana je klasa Job sa dodatim podacima.
    /// </summary>
    public class Job
    {

        [Key]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int Id { get; set; }

        /// <summary>
        /// Name nam govori naziv posla koji zaposleni obavlja.
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Name should be minimum 3 characters and a maximum of 50 characters")]
        public string Name { get; set; }
        /// <summary>
        /// Podatak koji govori kada je projekat zapocet.
        /// </summary>
        ///         
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name="Start_Date")]
        public DateTime Start_Date { get; set; }
        /// <summary>
        /// Podatak koji govori kada je projekat zavrsen.
        /// </summary>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name="End_Date")]
        public DateTime End_Date { get; set; }
        /// <summary>
        /// Podatak putem kojeg opisujemo posao.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(80,
            ErrorMessage = "Description should be minimum 3 charaters and a maximum of 80.")]        
        public string Description { get; set; }
        /// <summary>
        /// Strani kljuc koji nam govori koja vrsta posla se radila.
        /// </summary>

        
        [ForeignKey("JobType")]
        public int JobTypeID { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public virtual JobType JobType { get; set; }
    }
}
