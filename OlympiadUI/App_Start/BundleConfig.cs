using System.Web;
using System.Web.Optimization;

namespace Olympiads.WEB.App_Start
{
    public class BundleConfig
    {
        private const string CoreScriptBundlePath = "~/bundles/core/script";
        private const string ValidationScriptBundlePath = "~/bundles/validation";
        private const string CoreStyleBundlePath = "~/bundles/core/style";

        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(CoreScriptBundlePath).Include("~/Scripts/Core/jquery-{version}.js").Include("~/Scripts/Core/jquery-ext.js")
                                                              .Include("~/Scripts/Core/bootstrap.js"));

            bundles.Add(new ScriptBundle(ValidationScriptBundlePath).Include("~/Scripts/Validation/*.js"));

            bundles.Add(new StyleBundle(CoreStyleBundlePath).Include("~/Content/Core/bootstrap.css")
                                                            .Include("~/Content/Core/fa.css", new CssRewriteUrlTransform())
                                                            .Include("~/Content/Core/base.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}
