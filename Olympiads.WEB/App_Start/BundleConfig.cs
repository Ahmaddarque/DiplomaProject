using System.Web;
using System.Web.Optimization;

namespace Olympiads.WEB.App_Start
{
    public class BundleConfig
    {
        private const string CoreScriptBundlePath = "~/bundles/core/script";
        private const string ValidationScriptBundlePath = "~/bundles/validation";
        private const string CoreStyleBundlePath = "~/bundles/core/style";
        private const string ChartBundlePath = "~/bundles/amcharts";

        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(CoreScriptBundlePath).Include("~/Scripts/Core/jquery-{version}.js")
                                                              .Include("~/Scripts/Core/jquery-ext.js")
                                                              .Include("~/Scripts/Core/jquery-ui.min.js")
                                                              .Include("~/Scripts/Core/jquery.slimscroll.js")
                                                              .Include("~/Scripts/Core/jquery.mCustomScrollback.concat.js")
                                                              .Include("~/Scripts/Core/bootstrap.js"));

            bundles.Add(new ScriptBundle(ValidationScriptBundlePath).Include("~/Scripts/Validation/*.js"));

            bundles.Add(new StyleBundle(CoreStyleBundlePath).Include("~/Content/Core/bootstrap.css")
                                                            .Include("~/Content/Core/fa.css", new CssRewriteUrlTransform())
                                                            .Include("~/Content/Core/base.css"));
            bundles.Add(new ScriptBundle(ChartBundlePath).Include("~/Scripts/AmCharts/core.js")
                                                         .Include("~/Scripts/AmCharts/charts.js")
                                                         .Include("~/Scripts/AmCharts/themes/animated.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
