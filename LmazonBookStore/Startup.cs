using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LmazonBookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LmazonBookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Build this before using the dotnet command line
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookDBConnection"]);
            });

            //Connect with the Identity DB
            services.AddDbContext<AppIdentityDbContext>(options =>
               options.UseSqlite(Configuration["ConnectionStrings:IdentityConnection"]));

            //User has a role
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddScoped<IBookStoreRepository, EFBookStoreRepository>();

            services.AddScoped<ICheckOutRepository, EFCheckOutRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();

            services.AddSession();

            services.AddScoped<Basket>(x => SessionBasket.GetBasket(x));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddServerSideBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Build this before using the dotnet command line 
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            //set up the middleware components that implement the security policy.
            //These methods must appear between the UseRouting and UseEndpoints methods.
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    "categorypage",
                    "{category}/Page{pageNum}",
                    new { Controller = "Home", action = "Index" }
                );

                endpoints.MapControllerRoute
                (
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1 }
                ); 

                endpoints.MapControllerRoute
                (
                    "category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 }
                );

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();

                endpoints.MapBlazorHub();

                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
