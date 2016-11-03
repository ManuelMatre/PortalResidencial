using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PortalResidential_Web.Business.Security
{
    public class PortalAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                if (string.IsNullOrEmpty(SessionPersister.Username))
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new
                        {
                            controller = "Public",
                            action = "LogIn"
                        }));
                else
                {
                    PortalPrincipal rp = new PortalPrincipal();
                    if (!rp.IsInRole(Roles))
                        filterContext.Result = new RedirectToRouteResult(new
                            RouteValueDictionary(new
                            {
                                controller = "AccessDenied",
                                action = "Index"
                            }));
                }
            }
            catch (Exception)
            {
                filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new
                        {
                            controller = "Auth",
                            action = "Index"
                        }));
            }
        }
    }
}