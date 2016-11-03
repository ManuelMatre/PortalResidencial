using PortalResidential_Web.Business.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using PortalResidential_Web.Business.Services;

namespace PortalResidential_Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [PortalAuthorize(Roles = "appuser")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetReport()
        {
            ReportService reportService = new ReportService();
            var userService = new AppUsersService();
            var userList = userService.GetAll();
            FileParams fileParams = reportService.CreatePdf("ResidentReport.rdlc", userList, null);
            return File(fileParams.renderedBytes, fileParams.mimeType, "_Plantilla.pdf");
        }
    }
}