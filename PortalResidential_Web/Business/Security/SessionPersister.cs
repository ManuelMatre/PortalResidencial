using PortalResidential_Web.Business.Services;
using PortalResidential_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalResidential_Web.Business.Security
{
    public class SessionPersister
    {
        public static string UserId
        {
            get
            {
                SessionUser session = (SessionUser)HttpContext.Current.Session["TokenAuth"];
                if (HttpContext.Current == null)
                    return string.Empty;
                try
                {
                    var sessionVar = session.userid.ToString();
                    if (sessionVar != null)
                        return sessionVar as string;
                }
                catch (Exception)
                {
                    return null;
                }
                return null;
            }
        }
        public static string Username
        {
            get
            {
                SessionUser session = (SessionUser)HttpContext.Current.Session["TokenAuth"];
                if (HttpContext.Current == null)
                    return string.Empty;
                try
                {
                    var sessionVar = session.username;
                    if (sessionVar != null)
                        return sessionVar as string;
                }
                catch (Exception)
                {
                    return null;
                }
                return null;
            }
        }
        public static string[] Roles
        {
            get
            {
                SessionUser session = (SessionUser)HttpContext.Current.Session["TokenAuth"];
                try
                {
                    var sessionVar = session.roles;
                    if (sessionVar != null)
                        return sessionVar.Split(',') as string[];
                }
                catch (Exception)
                {
                    return null;
                }
                return null;
            }
        }
    }
}