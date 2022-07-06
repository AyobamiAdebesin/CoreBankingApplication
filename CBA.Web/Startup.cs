using CBA.Core.Models;
using CBA.DAL;
using CBA.DAL.Context;
using CBA.DAL.Implementations;
using CBA.DAL.Interfaces;
using CBA.Services.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CBA.Web
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
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                //services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                // {
                //  options.SignIn.RequireConfirmedEmail = true;
                //  })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
                options.TokenLifespan = TimeSpan.FromHours(5));
            services.AddMvc();
            services.AddControllersWithViews();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IGLAccountDAO, GLAccountDAO>();
            services.AddTransient<IGLCategoryDAO, GLCategoryDAO>();
            services.AddTransient<ICustomerDAO, CustomerDAO>();
            services.AddTransient<ICustomerAccountDAO, CustomerAccountDAO>();
            services.AddTransient<IAccountTypeManagementDAO, AccountTypeManagementDAO>();
            services.AddTransient<ITellerDAO, TellerDAO>();
            services.AddTransient<IBalanceSheetDAO, BalanceSheetDAO>();
            services.AddTransient<IMailService, MailService>();

            //services.AddTransient<AppUserSeedData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context, RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //seeder.SeedAdminUserAndRoles();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "Theme")),
                RequestPath = "/StaticFiles"
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //AppUserSeedData.Initialize(context, userManager, roleManager).Wait();
        }
    }
}
