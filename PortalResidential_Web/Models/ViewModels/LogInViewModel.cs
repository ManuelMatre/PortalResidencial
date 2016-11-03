using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalResidential_Web.Models
{
    public class LogInViewModel
    {
        [Required]
        [Display(Name = "Domicilio")]
        public int id_address { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}