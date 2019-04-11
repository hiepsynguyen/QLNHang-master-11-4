/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication8.Hubs;

namespace WebApplication8
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/hubs/chat");
            });
        }
    }
}*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication8.Hubs;
//using Microsoft.AspNetCore.Identity.UI.Services;
using WebApplication8.Services;
using WebApplication8.Controllers;
using WebApplication8.Models.ShoppingCart;
using WebApplication8.Models.IdentityModels;
using WebApplication8.Models.EmailService;
using WebApplication8.Models.StripePayment;
using Microsoft.AspNetCore.Routing.Constraints;
using WebApplication8.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Stripe;
using WebApplication8.Helper;
using DAL.QLNHangData;
//using WebApplication8.TempQLNHData;

namespace WebApplication8
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /*services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });*/

            services.AddDbContext<WebShopContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("QLNhaHangConnection")));

            services.AddDbContext<QLNhaHangContext>(options =>
                 options.UseSqlServer(
                     Configuration.GetConnectionString("QLNhaHangConnection")));


            /*services.AddIdentity<IdentityUser, IdentityRole>(options => options.Stores.MaxLengthForKeys = 128)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();*/

            services.AddIdentity<ApplicationUser, ApplicationRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddSignalR();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc(
                options =>
                {
                    options.Filters.Add(typeof(MyActionFilterController)); // by type
                    options.Filters.Add(new MyActionFilterController()); // an instance
                }
                ).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, options => options.ResourcesPath = "Resources")

                .AddDataAnnotationsLocalization().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { new CultureInfo("vi"), new CultureInfo("en") };

                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");

                options.SupportedCultures = supportedCultures;

                options.SupportedUICultures = supportedCultures;

            });

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddSingleton<MyActionFilterController>();
            services.AddSingleton<ShoppingCart>();
            services.AddScoped<IShoppingCart, ShoppingCart>();
            services.AddTransient<IShoppingCart, ShoppingCart>();
            services.AddSingleton<CustomerIdentity>();
            services.AddSingleton<EmailService>();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

            //this is the NB line for this post
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);
            PublicFunction.C_con = PublicFunction.connect(Configuration.GetConnectionString("QLNhaHangConnection"));
            
            /*var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);*/
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSession();


            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                // add the new route here.
                /*routes.MapRoute(
                  name: "Product_Detail",
                  template: "Product/Detail/{Id}/{para}.html",
                  defaults: new { controller = "Product", action = "Detail" },
                   constraints: new { Id = new IntRouteConstraint() });
                routes.MapRoute(
                 name: "Product_Cat",
                 template: "Product/Cat/{Id}/{para}",
                 defaults: new { controller = "Product", action = "Cat" },
                  constraints: new { Id = new IntRouteConstraint() });

                routes.MapRoute(
                name: "Product_Detai_1",
                template: "Product/Detail/{Id}/{para}",
                defaults: new { controller = "Product", action = "Detail" },
                 constraints: new { Id = new IntRouteConstraint() });

                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Admin", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                    */

                //Set tham số controller để mặc định khi load page lên sẽ chạy lên HomeQLNH 
                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Admin", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller=HomeQLNH}/{action=Index}/{id?}");

            });
            app.UseSignalR(routes => {
                routes.MapHub<ChatHub>("/chatHub");
            });
            //app.UseWebSockets();
        }
    }
}

