using System.Web.Optimization;

namespace I4PRJ_SmartStorage
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new StyleBundle("~/bundles/css").Include(
          "~/Content/bootstrap.min.css",
          "~/Content/font-awesome.min.css",
          "~/Content/bootstrap-social.css",
          "~/Content/animate.min.css",
          "~/Content/style.css"
      ));

      bundles.Add(new ScriptBundle("~/bundles/script").Include(
          "~/Scripts/modernizr/modernizr-2.9.3.js",
          "~/Scripts/jquery/jquery-3.1.1.min.js",
          "~/Scripts/bootstrap/bootstrap.min.js",
          "~/Scripts/respond/respond.min.js",
          "~/Scripts/slimScroll/jquery.slimscroll.min.js",
          "~/Scripts/mentisMenu/metisMenu.min.js",
          "~/Scripts/toastr/toastr.min.js",
          "~/Scripts/bootbox/bootbox.min.js",
          "~/Scripts/inspinia/inspinia.js"
      ));

      bundles.Add(new ScriptBundle("~/bundles/validate").Include(
          "~/Scripts/jqValidate/jquery.validate.min.js",
          "~/Scripts/jqValidate/jquery.validate.unobtrusive.min.js",
          "~/Scripts/site/jquery.validate.fix.js"
          ));

      bundles.Add(new StyleBundle("~/bundles/datatables").Include(
          "~/Content/DataTables/datatables.min.css"
      ));

      bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
          "~/Content/DataTables/datatables.min.js"
      ));

      bundles.Add(new StyleBundle("~/bundles/wizardSteps").Include(
           "~/Content/wizardSteps/jquery.steps.css"
      ));

      bundles.Add(new ScriptBundle("~/bundles/wizardSteps").Include(
          "~/Scripts/wizardSteps/jquery.steps.js"
      ));
    }
  }
}