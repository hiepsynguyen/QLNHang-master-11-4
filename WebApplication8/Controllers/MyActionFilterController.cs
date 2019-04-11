using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication8.Models.UtilEntities;

namespace WebApplication8.Controllers
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MyActionFilterController : ActionFilterAttribute
    {
        public IUrlHelper _Url { get; set; }

        public MyActionFilterController()
        {

        }



        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //  throw new NotImplementedException();
            //  Console.WriteLine("abc");
            // var url = context.HttpContext.Request.Path;
            //context.HttpContext.Response.Redirect();  
            //if (context.HttpContext.) { }

            string cultureName = "vi";
            var request = context.HttpContext.Request;
            var cultureCookie = request.Cookies["Culture"];


            if (cultureCookie != null)
            {
                cultureName = cultureCookie;
            }

            var cultureInfo = new CultureInfo("vi");
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            var path = context.HttpContext.Request.PathBase == null ? context.HttpContext.Request.Path + "" : context.HttpContext.Request.PathBase.Value + context.HttpContext.Request.Path;
            if (path.ToLower().Contains("/admin/"))
            {
                //var ControllerName = context.Controller;
                // var ActionName = context.ActionDescriptor.a;
                if (!context.HttpContext.User.Identity.IsAuthenticated)
                {
                    if (!path.ToLower().Contains("/login"))
                    {
                        //var host = request.Host.ToUriComponent();
                        var a = StringRoute.getBaseUrl(context.HttpContext.Request);
                        context.HttpContext.Response.Redirect(StringRoute.getBaseUrl(context.HttpContext.Request) + "/Admin/Account/Login?returnUrl=" + path);

                    }
                }


            }

            base.OnActionExecuting(context);
        }
    }
}