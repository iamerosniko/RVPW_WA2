using System.Web;
using System.Web.Optimization;

namespace ProjectWorkplaceAzure
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/styles.bundle.css"));


            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                        "~/Scripts/inline.*",
                        "~/Scripts/polyfills.*",
                        "~/Scripts/scripts.*",
                        "~/Scripts/main.*"));
        }
    }
}
