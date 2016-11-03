using PortalResidential_Web.Models;
using PortalResidential_Web.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalResidential_Web.ExtensionMethods
{
    public static class Extension_Methods
    {
        public static List<SelectListItem> ToSelectItemList(this List<DefaultAddressBindingModel> objectList)
        {
            return objectList.Select(x => new SelectListItem
            {
                Value = x.id.ToString(),
                Text = x.address
            }).ToList();
        }
    }
}