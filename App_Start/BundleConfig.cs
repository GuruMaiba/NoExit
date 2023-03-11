using System.Web;
using System.Web.Optimization;

namespace NoExit
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include("~/Scripts/jquery.unobtrusive*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/jquery-ui.js",
                "~/Scripts/jquery-ui.min.js",
                "~/Scripts/datepicker-ru.js"

                ));
            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/NProgress").Include(
          "~/Scripts/nprogress.js"
          ));
            bundles.Add(new ScriptBundle("~/DateRangePicker").Include(
          "~/Scripts/moment.min.js",
          "~/Scripts/daterangepicker.js"
          ));
            bundles.Add(new ScriptBundle("~/jsMaskedInput").Include(
          "~/Scripts/jquery.maskedinput.min.js"
          ));
            bundles.Add(new ScriptBundle("~/Gallery").Include(
                "~/Scripts/masonry.pkgd.min.js",
                "~/Scripts/imagesloaded.pkgd.min.js",
                "~/Scripts/cbpGridGallery.js",
                "~/Scripts/classie.js"
                ));
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css",
                "~/Content/site.css",
                      
                      "~/Content/nprogress.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/jquery-ui.theme.css"));

           



            
        }
    }
}
