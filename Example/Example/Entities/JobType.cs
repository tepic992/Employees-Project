using Example.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Entities
{
    /// <summary>
    /// Kreirana je klasa sa podacima.
    /// </summary>
    public class JobType
    {
        /// <summary>
        /// Primarni kljuc putem kojeg pronalazimo tip posla.
        /// </summary>
        /// 
        [Key]
        [Required(ErrorMessage = "Should not be null or empty.")]
        public int Id { get; set; }

        /// <summary>
        /// Podatak koji nam prikazuje naziv tipa posla.
        /// </summary>
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(40, MinimumLength = 2,
        ErrorMessage = "Name should be minimum 2 characters and a maximum of 40 characters")]
        [DataType(DataType.Text)]
        [Unique]
        public string Name { get; set; }

        /// <summary>
        /// Podatak koji nam pokazuje koliko je dana zaposlen na poslu.
        /// </summary>
        /// 

        public int Day { get; set; }
        /// <summary>
        /// Podatak koji nam pokazuje koliko je meseci zaposlen na poslu.
        /// </summary>
        /// 

        public int Mounth { get; set; }
        /// <summary>
        /// Podatak koji nam pokazuje koliko je godina zaposlen na poslu.
        /// </summary>
        /// 

        public int Year { get; set; }

        /// <summary>
        /// Opisuje tip posla koji zaposleni radi.
        /// </summary>
        /// 
        [Required(ErrorMessage = "{0} is required" )]
        [StringLength(80, MinimumLength =20,
            ErrorMessage ="Description should be minimum 3 charaters and a maximum of 80.")]       
        public string Description;
        
       
    }
}
