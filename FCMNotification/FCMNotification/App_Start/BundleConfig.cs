using System.Web;
using System.Web.Optimization;
using System.Web.Optimization.React;

namespace FCMNotification
{
    public class BundleConfig
    {
        // 如需「搭配」的詳細資訊，請瀏覽 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/main.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/JSX/react").Include(
                        "~/Scripts/JSX/tutorial1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/fileinput").Include(
                        "~/Scripts/fileinput.js"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-fileinput/fileinput").Include(
                      "~/Content/bootstrap-fileinput/css/fileinput.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                      "~/Scripts/lib/react.js",
                      "~/Scripts/lib/reflux.js",
                      "~/Scripts/lib/react-with-addons.js"));

            bundles.Add(new BabelBundle("~/bundles/AD").Include(
                    // Add your JSX files here
                    "~/Scripts/JSX/ADRepeter.jsx"
                    ));
            bundles.Add(new BabelBundle("~/bundles/main").Include(
                    // Add your JSX files here
                    "~/Scripts/JSX/DnDTraning.jsx"
                    ));

            bundles.Add(new BabelBundle("~/bundles/reflux").Include(
                    "~/Scripts/JSX/refluxTraning.jsx",
                    "~/Scripts/JSX/ADRepeter.jsx"
                    ));
        }
    }
}
