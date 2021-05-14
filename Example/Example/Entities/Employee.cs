using Example.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Example.Entities
{
    /// <summary>
    /// Kreirana je klasa Employee sa dodatim atributima
    /// </summary>
    public class Employee : Worker
    {

        /// <summary>
        /// Id predstavlja Primary Key preko kojeg pronalazimo Menadzera na projektu.
        /// </summary>
        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }              
       public virtual Manager Manager { get; set; }
                  
    }
}
