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
          "~/Content/bootstrap-social.css"
      ));

      bundles.Add(new ScriptBundle("~/bundles/script").Include(
          "~/Scripts/jquery-3.1.1.min.js",
          "~/Scripts/bootstrap.min.js",
          "~/Scripts/modernizr-2.9.3.js",
          "~/Scripts/jquery.slimscroll.min.js",
          "~/Scripts/metisMenu.min.js",
          "~/Scripts/inspinia.js"
      ));

      bundles.Add(new ScriptBundle("~/bundles/validate").Include(
          "~/Scripts/jquery.validate.min.js",
          "~/Scripts/jquery.validate.unobtrusive.min.js",
          "~/Scripts/jquery.validate.fix.js"
          ));

      bundles.Add(new StyleBundle("~/Content/datatables").Include(
          "~/Content/dataTables/autoFill.dataTables.min.css",
          "~/Content/dataTables/buttons.dataTables.min.css",
          "~/Content/dataTables/datatables.min.css",
          "~/Content/dataTables/keyTable.dataTables.min.css",
          "~/Content/dataTables/responsive.dataTables.min.css",
          "~/Content/dataTables/select.dataTables.min.css"
      ));

      bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
          "~/Scripts/dataTables/dataTables.autoFill.min.js",
          "~/Scripts/dataTables/dataTables.buttons.min.js",
          "~/Scripts/dataTables/dataTables.keyTable.min.js",
          "~/Scripts/dataTables/dataTables.reponsice.min.js",
          "~/Scripts/dataTables/dataTables.select.min.js",
          "~/Scripts/dataTables/datatables.min.js",
          "~/Scripts/dataTables/jszip.min.js",
          "~/Scripts/dataTables/pdfmake.min.js",
          "~/Scripts/dataTables/vfs_fonts.js",
          "~/Scripts/datatables.script.js"
      ));
    }
  }
}