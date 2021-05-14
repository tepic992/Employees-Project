using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Entities
{
    public class Manager : Worker
    {

        /// <summary>
        /// Id predstavlja Primary Key preko kojeg pronalazimo vrstu menadzera na projektu.
        /// </summary>
        [ForeignKey("ManagerType")]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int ManagerTypeId { get; set; }

        public virtual ManagerType ManagerType { get; set; }

    }
}
