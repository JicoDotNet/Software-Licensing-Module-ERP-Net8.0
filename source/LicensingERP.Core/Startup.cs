﻿//using System;
//using System.Net;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.DependencyInjection;

//namespace LicensingERP
//{
//    public class Startup
//    {
//        // This method gets called by the runtime. Use this method to add services to the container.
//        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.Configure<CookiePolicyOptions>(options =>
//            {
//                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
//                options.CheckConsentNeeded = context => true;
//                options.MinimumSameSitePolicy = SameSiteMode.None;
//            });
//            services.AddDistributedMemoryCache();
//            services.AddSession(options =>
//            {
//                options.Cookie.Name = "ASP.NET_SessionId";
//                // Set a short timeout for easy testing.
//                options.IdleTimeout = TimeSpan.FromHours(1);
//                options.Cookie.HttpOnly = true;
//                // Make the session cookie essential
//                options.Cookie.IsEssential = true;
//            });
//            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//            services.AddResponseCaching();
//            services.AddSession();
//            services.AddMemoryCache();
//            services.AddMvc();

//        }


//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseStaticFiles();
//            app.UseCookiePolicy();
//            app.UseResponseCaching();
//            app.UseSession();
//            app.UseExceptionHandler(
//                options =>
//                {
//                    options.Run(
//                        async context =>
//                        {
//                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                            context.Response.ContentType = "text/html";
//                            var ex = context.Features.Get<IExceptionHandlerFeature>();
//                            if (ex != null)
//                            {
//                                var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace }";
//                                await context.Response.WriteAsync(err).ConfigureAwait(false);
//                            }
//                        });
//                }
//            );
//            app.UseMvc(routes =>
//            {
//                routes.MapAreaRoute(
//                    name: "MyAreaReport",
//                    areaName: "Report",
//                    template: "Report/{controller=Home}/{action=Index}/{id?}");

//                routes.MapRoute(
//                   name: "default",
//                   template: "{controller=Home}/{action=Index}/{id?}/{id2?}");
//            });
//        }
//    }
//}


using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LicensingERP
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "ASP.NET_SessionId";
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddResponseCaching();
            services.AddMemoryCache();
            services.AddControllersWithViews();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options =>
                {
                    options.Run(async context =>
                    {
                        context.Response.StatusCode = context.Response.StatusCode;// (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "text/html";
                        var ex = context.Features.Get<IExceptionHandlerFeature>();                        
                        if (ex != null)
                        {
                            var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace}";
                            await context.Response.WriteAsync(err).ConfigureAwait(false);
                        }
                    });
                });
            }

            //app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.SameAsRequest
            });

            app.UseResponseCaching();
            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "MyAreaReport",
                    areaName: "Report",
                    pattern: "Report/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",                    
                    pattern: "{controller=Home}/{action=Index}/{id?}/{id2?}");                
            });
        }
    }
}
