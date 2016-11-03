using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalResidential_Web.Models.BindingModels
{
    public class DefaultAddressBindingModel
    {
        public long id { get; set; }
        public string address { get; set; }
        public bool isavailable { get; set; }
    }
}