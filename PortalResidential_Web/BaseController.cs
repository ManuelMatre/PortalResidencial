using PortalResidential_Web.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PortalResidential_Web
{
    public class BaseController : Controller
    {
        public AppUserBindingModel CurrentUser
        {
            get
            {
                if (HttpContext.User == null || HttpContext.User.Identity.AuthenticationType != "Forms")
                    return null;
                if (Session["CurrentUser"] != null)
                    return (AppUserBindingModel)Session["CurrentUser"];
                var identity = HttpContext.User.Identity;
                var ticket = ((FormsIdentity)identity).Ticket;
                int userId;
                if (!int.TryParse(ticket.UserData, out userId))
                    return null;

                //using (var db = new DbEntities(connectionString))
                //{
                //    Session["CurrentUser"] = db.Users.SingleOrDefault(u => u.ID == userId));
                //}

                return (AppUserBindingModel)Session["CurrentUser"];
            }

            set { Session["CurrentUser"] = value; }
        }
    }
}