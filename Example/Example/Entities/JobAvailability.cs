using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Entities
{
    /// <summary>
    /// Kreirana klasa koja predstavlja izbor posla za svakog zaposlenog.
    /// </summary>

    public class JobAvailability
    {

        /// <summary>
        /// Primarni kljuc klase putem koji povezuje Employee i Job.
        /// </summary>
        /// 
        [Key]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int Id { get; set; }

        /// <summary>
        /// Dodat je strani kljuc Employee.
        /// </summary>
        [ForeignKey("Employee")]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int EmployeeID { get; set; }


        /// <summary>
        /// Dodat je strani kljuc Job.
        /// </summary>
        [ForeignKey("Job")]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int JobID { get; set; }

        /// <summary>
        /// Navigacioni proprety za Job.
        /// </summary>
        public virtual Job Job { get; set; }
        /// <summary>
        /// Navigacioni property za Employee.
        /// </summary>
        public virtual Employee Employee { get; set; }

        
    }
}
