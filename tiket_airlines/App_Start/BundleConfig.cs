using System.Web;
using System.Web.Optimization;

namespace tiket_airlines
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
      
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
               "~/Scripts/jquery.min.js",
               "~/Scripts/bootstrap.min.js",
               "~/Scripts/jquery.fullpage.extensions.min.js",
              
               "~/Scripts/material.min.js",
               "~/Scripts/ripples.min.js"


               ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.


            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/style.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/bootstrap-material-design.min.css",
                      "~/Content/css/jquery.fullpage.css",
                      "~/Content/css/ripples.min.css",
                      "~/Content/css/font-awesome/font-awesome.min.css"
                      ));
        }
    }
}
