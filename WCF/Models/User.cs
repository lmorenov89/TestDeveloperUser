using System;
using System.ComponentModel.DataAnnotations;

namespace WCF.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Birthday { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public Int16 Gender { get; set; }
    }
}