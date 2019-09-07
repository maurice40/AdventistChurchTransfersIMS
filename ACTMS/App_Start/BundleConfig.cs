using System.Web;
using System.Web.Optimization;

namespace ACTMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                       "~/Scripts/jquery-{version}.js",
                       "~/Scripts/bootstrap.js",
                       "~/scripts/bootbox.js",
                       "~/Scripts/respond.js",
                       "~/scripts/datatables/jquery.datatables.js",
                       "~/scripts/datatables/datatables.bootstrap.js",
                       "~/scripts/typeahead.bundle.js",
                       "~/scripts/toastr.js",
                        "~/scripts/jquery-latest.js",
                        "~/scripts/light-bootstrap-dashboard.js",
                        "~/scripts/demo.js",
                        "~/scripts/bootstrap-notify.js",
                        "~/scripts/bootstrap-select.js",
                        "~/scripts/chartist.min.js"

                     ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-lumen.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/content/typeahead.css",
                      "~/content/toastr.css",
                      "~/content/animate.min.js",
                      "~/content/light-bootstrap-dashboard.css",
                      "~/content/pe-icon-7-stroke.css",
                      "~/content/demo.css",
                      "~/Content/site.css"));
        }
    }
}
