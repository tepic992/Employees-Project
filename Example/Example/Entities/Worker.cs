using Example.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Entities
{
    public abstract class Worker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int Id { get; set; }

        /// <summary>
        /// Ovaj podatak nam predstavlja ime zaposlenog.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 3,
        ErrorMessage = "First Name should be minimum 3 characters and a maximum of 20 characters")]
        [Display(Name = "First Name")]
        public string Name { get; set; }

        /// <summary>
        /// Ovaj podatak nam predstavlja prezime zaposlenog.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(20, MinimumLength = 3,
       ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 20 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Podatak koji govori o datumu zaposlenja.
        /// </summary>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfEmployee { get; set; }


        [DataType(DataType.Currency)]
        public decimal Price { get; set; }


        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Unique]
        public string Email { get; set; }
    }
}
