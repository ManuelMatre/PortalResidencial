using System.Web.Optimization;

namespace PortalResidential_Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Content/External/jQuery/jquery-3.1.1.min.js")
                .Include("~/Content/External/bootstrap/js/bootstrap.min.js")
                .Include("~/Content/External/select2/select2.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/External/bootstrap/css/bootstrap.min.css",
                      "~/Content/External/select2/select2.min.css"));

            bundles.Add(new StyleBundle("~/Content/Own/css").Include(
                      "~/Content/Layout/*.css"));
        }
    }
}