using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCRUD.Models.ViewModels
{
    public class TablaViewModel
    {
       
            public int id { get; set; }
            [Required]
            [StringLength(50)]
            [Display(Name = "Nombre")]
            public string nombre { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Correo Electrónico")]
            public string correo { get; set; }
            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Fecha De Nacimiento")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime fechaNacimiento { get; set; }

        
    }
}