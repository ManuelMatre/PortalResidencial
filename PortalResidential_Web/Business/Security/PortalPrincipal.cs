using PortalResidential_Web.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace PortalResidential_Web.Business.Security
{
    public class PortalPrincipal : IPrincipal
    {
        public PortalPrincipal()
        {
            this.Identity = new GenericIdentity(SessionPersister.Username);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => SessionPersister.Roles.Contains(r));
        }
    }
}