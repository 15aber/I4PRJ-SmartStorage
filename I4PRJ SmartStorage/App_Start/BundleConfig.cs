using System.Web.Optimization;

namespace I4PRJ_SmartStorage
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/animate.min.css",
                      "~/Content/style.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/bootstrap-social.css",
                      "~/Content/DataTables/css/dataTables.min.css",
                      "~/content/datatables/css/datatables.bootstrap.css",
                      "~/content/toastr.css",
                      "~/content/validation-error.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                        "~/Scripts/jquery-3.1.1.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/modernizr-2.9.3.js",
                        "~/Scripts/inspinia.js",
                        "~/Scripts/jquery.slimscroll.min.js",
                        "~/Scripts/metisMenu.min.js",
                        "~/Scripts/pace.min.js",
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                        "~/Scripts/toastr.min.js",
                        "~/Scripts/bootbox.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/validate").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
        }
    }
}
