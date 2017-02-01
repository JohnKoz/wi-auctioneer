using System.Web;
using System.Web.Optimization;

namespace surplus_auctioneer_webapp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerytablesorter").Include(
                        "~/Scripts/jquery.tablesorter.js",
                        "~/Scripts/jquery.tablesorter.combined.js",
                        "~/Scripts/jquery.tablesorter.pager.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/my-js").Include(
                        "~/Scripts/my/Main.js",
                        "~/Scripts/my/Views/_Shared.js",
                        "~/Scripts/my/Views/Search.js",
                        "~/Scripts/my/Views/EndingSoon.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jquery.tablesorter.pager.css",
                      "~/Content/filter.formatter.min.css",
                      "~/Content/dragtable.mod.min.css",
                      "~/Content/theme.blackice.min.css",
                      "~/Content/theme.blue.min.css",
                      "~/Content/site.css"));
        }
    }
}
