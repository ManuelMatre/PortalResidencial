using PortalResidential_Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalResidential_Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Dirección")]
        public int id_address { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Debe introducir solo dígitos.")]
        [MinLength(10, ErrorMessage = "Debe introducir 10 dígitos"), MaxLength(10, ErrorMessage = "Debe introducir 10 dígitos")]
        public string telephone { get; set; }

        [Display(Name = "Correo")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "La {0} debe contener al menos {2} caracteres.", MinimumLength = 6)]
        [Display(Name = "Contraseña")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string repassword { get; set; }
    }
}