using PortalResidential_Web.Business.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalResidential_Web.Controllers
{
    public class DebtsController : Controller
    {
        // GET: Debts
        [PortalAuthorize(Roles ="admin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}