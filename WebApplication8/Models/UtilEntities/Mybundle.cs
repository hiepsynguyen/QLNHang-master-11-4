using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models.UtilEntities
{
    public class MybundleRegister
    {
        private const string path_ = "";

        public static Bundle_ LTE211CSS = new Bundle_()
        {
            name = "LTE211/css",
            type = 0,//This is a bundle css Files
            arr_sc = new string[] {
                 "Template/Admin/LTE/211/bootstrap/css/bootstrap.min.css",
                     "Template/Admin/LTE/211/font-awesome/4.3.0/css/font-awesome.min.css",
                     "Template/Admin/LTE/211/ionicons/2.0.1/css/ionicons.min.css",
                     "Template/Admin/LTE/211/dist/css/AdminLTE.min.css",
                     "Template/Admin/LTE/211/dist/css/skins/_all-skins.min.css",
                     "Template/Admin/LTE/211/plugins/iCheck/flat/blue.css",
                     "Template/Admin/LTE/211/plugins/morris/morris.css",
                     "Template/Admin/LTE/211/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
                     "Template/Admin/LTE/211/plugins/datepicker/datepicker3.css",
                     "Template/Admin/LTE/211/plugins/daterangepicker/daterangepicker-bs3.css",
                     //"Template/Admin/LTE/211/plugins/daterangepicker/new/jquery.datetimepicker.css",
                     "Template/Admin/LTE/211/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                     "Template/Admin/LTE/211/plugins/iCheck/square/blue.css",
                     "Content/AdminSite.css"
            }

        };
        public static Bundle_ LTE211JS = new Bundle_()
        {
            name = "",
            type = 1,
            arr_sc = new string[] {
                   "Template/Admin/LTE/211/plugins/jQuery/jQuery-2.1.4.min.js",
                         "Template/Admin/LTE/211/jQueryUI/1.11.2/jquery-ui.min.js",
                        "Template/Admin/LTE/211/bootstrap/js/bootstrap.min.js",
                        "Template/Admin/LTE/211/raphael/2.1.0/raphael-min.js",
                        "Template/Admin/LTE/211/plugins/morris/morris.min.js",
                        "Template/Admin/LTE/211/plugins/sparkline/jquery.sparkline.min.js",
                        "Template/Admin/LTE/211/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                        "Template/Admin/LTE/211/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                        "Template/Admin/LTE/211/plugins/knob/jquery.knob.js",
                        "Template/Admin/LTE/211/moment/2.10.0/moment.min.js",

                        "Template/Admin/LTE/211/plugins/daterangepicker/daterangepicker.js",
                        "Template/Admin/LTE/211/plugins/daterangepicker/new/jquery.mask.min.js",
                        "Template/Admin/LTE/211/plugins/datepicker/bootstrap-datepicker.js",
                        "Template/Admin/LTE/211/plugins/slimScroll/jquery.slimscroll.min.js",
                        //"~/Themes/Admin/LTE/211/plugins/fastclick/fastclick.min.js",
                        "Template/Admin/LTE/211/dist/js/app.min.js",
                        //"~/Themes/Admin/LTE/211/dist/js/pages/dashboard.js",
                        "Scripts/ckeditor/ckeditor.js",
                         "Scripts/NumberJS/numeral.min.js",
                        "Template/Admin/LTE/211/plugins/iCheck/icheck.min.js",
                        "Template/Admin/LTE/211/dist/js/demo.js",
                        "Scripts/setup_format_number.js"

            }
        };
        public static Bundle_ Modernizr = new Bundle_()
        {
            name = "modernizr",
            type = 1,
            arr_sc = new string[] {
                "Scripts/modernizr-2.6.2.js"
            }
        };
        public static Bundle_ ContentCSS = new Bundle_()
        {
            name = "contentCss",
            type = 0,
            arr_sc = new string[] {
                 "Content/bootstrap.css",
                      "Content/site.css"
            }

        };
        public static Bundle_ BoostrapValidatorCSS = new Bundle_()
        {
            name = "BoostrapValidatorCSS",
            type = 0,
            arr_sc = new string[] {

            }

        };
        public static Bundle_ JTableCSS = new Bundle_()
        {
            name = "JTableCSS",
            type = 0,
            arr_sc = new string[] {
                "Scripts/DataTable/media/css/jquery.dataTables.min.css",
                     "Scripts/DataTable/extensions/colvis/css/dataTables.colvis.jqueryui.css",
                    "Scripts/DataTable/extensions/colvis/css/dataTables.colVis.min.css",
                     "Scripts/DataTable/extensions/ColReorder/css/dataTables.colReorder.min.css",
                     "Scripts/DataTable/extensions/TableTools/css/dataTables.tableTools.min.css"
            }

        };
        public static Bundle_ BootstrapValidatorJS = new Bundle_()
        {
            name = "BootstrapValidatorJS",
            type = 1,
            arr_sc = new string[] {
                "Scripts/BootstrapValidator/js/bootstrapValidator.min.js"
            }

        };
        public static Bundle_ JTableJS = new Bundle_()
        {
            name = "JTableJS",
            type = 1,
            arr_sc = new string[] {
               "Scripts/DataTable/media/js/jquery.dataTables.min.js",
             "Scripts/DataTable/extensions/colvis/js/dataTables.colVis.min.js",
              "Scripts/DataTable/extensions/ColReorder/js/dataTables.colReorder.min.js",
               "Scripts/DataTable/extensions/TableTools/js/dataTables.tableTools.min.js"
            }

        };
        public static Bundle_ UnicaseJS = new Bundle_()
        {
            name = "UnicaseJS",
            type = 1,
            arr_sc = new string[] {
              "Template/User/Unicase/assets/js/jquery-1.11.1.min.js",
                       "Template/User/Unicase/assets/js/bootstrap.min.js",
                       "Template/User/Unicase/assets/js/bootstrap-hover-dropdown.min.js",
                       "Template/User/Unicase/assets/js/owl.carousel.min.js",
                       "Template/User/Unicase/assets/js/echo.min.js",
                       "Template/User/Unicase/assets/js/jquery.easing-1.3.min.js",
                       "Template/User/Unicase/assets/js/bootstrap-slider.min.js",
                      // "/Template/User/Unicase/assets/js/jquery.rateit.min.js",
                     //  "/Template/User/Unicase/assets/js/lightbox.min.js",
                        "Template/User/Unicase/assets/js/bootstrap-select.min.js",
                      // "/Template/User/Unicase/assets/js/wow.min.js",
                       "Template/User/Unicase/assets/js/scripts.js",
                       "Scripts/NumberJS/numeral.min.js",
                    "Scripts/LoadCart.js",
                    "Scripts/SearchAjax.js",
                   "Scripts/FlyingCart.js",
                    "Scripts/RemoveCartAjax.js",
                    "Scripts/Dropdown.js",
                    "Scripts/Paging.js",
                    "Scripts/process_box_chat.js",
                    //"/lib/signalr/jquery.signalR.js",
                    "Scripts/setup_format_number.js"
                   
                      //"/Scripts/ChatService/guest_process_chat.js"
                      // "/Template/User/Unicase/switchstylesheet/switchstylesheet.js"
            }

        };

        public static Bundle_ UnicaseCSS = new Bundle_()
        {
            name = "UnicaseCSS",
            type = 0,
            arr_sc = new string[] {
                 "Template/User/Unicase/assets/css/bootstrap.min.css",
                    "Template/User/Unicase/assets/css/main.css",
                   //  "/Template/User/Unicase/assets/css/dark-green.css",
                    "Template/User/Unicase/assets/css/owl.carousel.css",
                     "Template/User/Unicase/assets/css/owl.transitions.css",
                    "Template/User/Unicase/assets/css/lightbox.css",
                    "Template/User/Unicase/assets/css/animate.min.css",
                  //  "/Template/User/Unicase/assets/css/rateit.css",
                    "Template/User/Unicase/assets/css/bootstrap-select.min.css",
                    "Template/User/Unicase/assets/css/config.css",
                    "Content/Site.css"
            }
        };
        public MybundleRegister()
        {


        }

        /*
         Danh sách các bundle
             */




        public static string AddScript(Bundle_ bundle, string base_url = "", HttpRequest _request = null)
        {
            
            var html = "";
            var tag_open = bundle.type == 0 ? "link" : "script";
            var tag_close = "/" + tag_open;
            base_url = _request is null ? "" + base_url : string.Format("{0}://{1}", _request.Scheme,
            _request.Host) + base_url;
            foreach (string b in bundle.arr_sc)
            {
                var ele = "";
                ele = "<" + tag_open + " " + (bundle.type == 0 ? "href=\"" + base_url + "" + b + "\" type=\"text/css\" rel=\"stylesheet\"" : "src=\"" + base_url + "" + b + "\"  type=\"text/javascript\"") + "" + ">" + "<" + tag_close + ">\n";
                html += ele;
            }
            return html;
        }

    }
}
