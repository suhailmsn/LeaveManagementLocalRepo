using System;
using System.Web;
using System.Web.Optimization;

namespace LeaveManagement
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(new ScriptBundle("~/bundles/bootstrapscript").Include("~/Scripts/jquery-3.5.1.js", "~/Scripts/popper.js", "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/bundles/bootstrapstyle").Include("~/Content/bootstrap.css", "~/Content/CustomLayout.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}
