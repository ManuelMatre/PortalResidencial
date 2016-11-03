using PortalResidential_Web.Business.Business;
using PortalResidential_Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalResidential_Web.Business.Repositories
{
    public class AppUsersRepository : Repository<appusers>
    {
        public AppUsersRepository(ResidentialEntities context) : base(context)
        {
        }
    }
}