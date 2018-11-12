using System.Web;
using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            ///admin area
            /// 
            bundles.Add(new ScriptBundle("~/bundles/admin/js").Include(
                     "~/plugins/pace/pace.min.js", "~/js/jquery-2.1.1.min.js", "~/js/bootstrap.min.js",
                     "~/plugins/fast-click/fastclick.min.js", "~/plugins/nanoscrollerjs/jquery.nanoscroller.min.js",
                     "~/plugins/metismenu/metismenu.min.js", "~/plugins/pace/pace.min.js", "~/js/scripts.js", "~/plugins/switchery/switchery.min.js",
                      "~/plugins/parsley/parsley.min.js", "~/plugins/jquery-steps/jquery-steps.min.js", "~/plugins/bootstrap-select/bootstrap-select.min.js"
                      , "~/plugins/bootstrap-wizard/jquery.bootstrap.wizard.min.js"
                      , "~/plugins/masked-input/bootstrap-inputmask.min.js", "~/plugins/bootstrap-validator/bootstrapValidator.min.js",
                      "~/plugins/flot-charts/jquery.flot.min.js", "~/plugins/flot-charts/jquery.flot.resize.min.js",
                      "~/plugins/flot-charts/jquery.flot.spline.js", "~/plugins/flot-charts/jquery.flot.pie.min.js",
                      "~/plugins/moment/moment.min.js", "~/plugins/moment-range/moment-range.js", "~/plugins/flot-charts/jquery.flot.tooltip.min.js",
                      "~/plugins/flot-charts/jquery.flot.categories.js", "~/plugins/jquery-ricksaw-chart/js/raphael-min.js",
                      "~/plugins/jquery-ricksaw-chart/js/d3.v2.js", "~/plugins/jquery-ricksaw-chart/js/rickshaw.min.js",
                      "~/plugins/jquery-ricksaw-chart/ricksaw.js", "~/plugins/summernote/summernote.min.js",
                      "~/plugins/screenfull/screenfull.js", "~/js/demo/wizard.js", "~/js/demo/form-wizard.js",
                      "~/js/demo/dashboard-v2.js"));

            bundles.Add(new StyleBundle("~/Content/admin/css").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/style.css", "~/plugins/font-awesome/css/font-awesome.min.css", "~/plugins/switchery/switchery.min.css", "~/plugins/bootstrap-select/bootstrap-select.min.css", 
                      "~/plugins/jquery-ricksaw-chart/css/rickshaw.css", "~/plugins/bootstrap-validator/bootstrapValidator.min.css",
                      "~/css/demo/jquery-steps.min.css", "~/plugins/summernote/summernote.min.css","~/css/demo/jasmine.css",
                      "~/plugins/pace/pace.min.css", "~/http://fonts.googleapis.com/css?family=Roboto+Slab:400,300,100,700",
                      "~/http://fonts.googleapis.com/css?family=Roboto:500,400italic,100,700italic,300,700,500italic,400"));
        }
    }
}
