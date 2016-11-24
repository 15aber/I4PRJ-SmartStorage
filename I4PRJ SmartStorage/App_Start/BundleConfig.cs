using System.Web.Optimization;

namespace I4PRJ_SmartStorage
{
  public class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new StyleBundle("~/Content/css").Include(
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
          "~/Scripts/inspinia/inspinia.js"
      ));

      bundles.Add(new ScriptBundle("~/bundles/validate").Include(
          "~/Scripts/jqValidate/jquery.validate.min.js",
          "~/Scripts/jqValidate/jquery.validate.unobtrusive.min.js",
          "~/Scripts/site/jquery.validate.fix.js"
          ));

      bundles.Add(new StyleBundle("~/Content/datatables").Include(
          "~/Content/dataTables/datatables.min.css",
          "~/Content/dataTables/dataTables.bootstrap.min.css",
          "~/Content/dataTables/autoFill.dataTables.min.css",
          "~/Content/dataTables/buttons.dataTables.min.css",
          "~/Content/dataTables/keyTable.dataTables.min.css",
          "~/Content/dataTables/responsive.dataTables.min.css",
          "~/Content/dataTables/select.dataTables.min.css"
      ));

      bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
          "~/Scripts/dataTables/datatables.min.js",
          "~/Scripts/dataTables/jquery.dataTables.min.js",
          "~/Scripts/dataTables/dataTables.autoFill.min.js",
          "~/Scripts/dataTables/dataTables.buttons.min.js",
          "~/Scripts/dataTables/dataTables.keyTable.min.js",
          "~/Scripts/dataTables/dataTables.reponsice.min.js",
          "~/Scripts/dataTables/dataTables.select.min.js",
          "~/Scripts/jszip/jszip.min.js",
          "~/Scripts/pdfmake/pdfmake.min.js",
          "~/Scripts/pdfmake/vfs_fonts.js"
      ));

      bundles.Add(new StyleBundle("~/Content/wizardSteps").Include(
           "~/Content/wizardSteps/jquery.steps.css"
      ));

      bundles.Add(new ScriptBundle("~/bundles/wizardSteps").Include(
          "~/Scripts/wizardSteps/jquery.steps.min.js"
      ));
    }
  }
}