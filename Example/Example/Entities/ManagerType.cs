using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Entities
{
    /// <summary>
    /// Kreirana je klasa ManagerType sa dodatim atributima.
    /// </summary>
    public class ManagerType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(10,
        ErrorMessage = "TypeName should be maximum 10 characters")]
        [Display(Name = "TypeName")]
        public string TypeName { get; set; }

        

        

   

    }

}



