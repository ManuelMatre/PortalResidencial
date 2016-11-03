using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalResidential_Web.Models.BindingModels
{
    public class AppUserBindingModel
    {
        public int id { get; set; }
        public long id_address { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public DateTime reg_date { get; set; }
    }
}