using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Repositories;
using Data;
using Data.Contexts;
using Data.Repositories;
using Manage.Constraints;
using Manage.Helpers;
using Manage.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Manage
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDbContext<ProkonContext>(option =>
                            option.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase"), x => x.MigrationsAssembly("Data")));

            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<ProkonContext>();

            //Constraints
            services.Configure<RouteOptions>(options => options.ConstraintMap.Add("languages", typeof(LanguageConstraint)));
            //

            //repositories
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAboutComponentRepository, AboutComponentRepository>();
            services.AddScoped<IAboutPhotoRepository, AboutPhotoRepository>();
            services.AddScoped<ICareerComponentRepository, CareerComponentRepository>();
            services.AddScoped<ICareerAppContentRepository, CareerAppContentRepository>();
            services.AddScoped<ICareerFormComponentRepository, CareerFormComponentRepository>();
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<IContactComponentRepository, ContactComponentRepository>();
            services.AddScoped<IContactMessageRepository, ContactMessageRepository>();
            services.AddScoped<IContentAccessComponentRepository, ContentAccessComponentRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IEthicsComponentRepository, EthicsComponentRepository>();
            services.AddScoped<IEthicsFileComponentRepository, EthicsFileComponentRepository>();
            services.AddScoped<IEthicsHotlineFormComponentRepository, EthicsHotlineFormComponentRepository>();
            services.AddScoped<IFooterPartnerRepository, FooterPartnerRepository>();
            services.AddScoped<IPartnerComponentRepository, PartnerComponentRepository>();
            services.AddScoped<IPartnerRepository, PartnerRepository>();
            services.AddScoped<IHomeSliderComponentRepository, HomeSliderComponentRepository>();
            services.AddScoped<IGalleryComponentRepository, GalleryComponentRepository>();
            services.AddScoped<IGalleryComponentPhotoRepository, GalleryComponentPhotoRepository>();
            services.AddScoped<IGeneralApplyFileRepository, GeneralApplyFileRepository>();
            services.AddScoped<IGeneralApplyRepository, GeneralApplyRepository>();
            services.AddScoped<IGovernanceComponentRepository, GovernanceComponentRepository>();
            services.AddScoped<ILicenceRepository, LicenceRepository>();
            services.AddScoped<IManagementRepository, ManagementRepository>();
            services.AddScoped<INavComponentRepository, NavComponentRepository>();
            services.AddScoped<INavSubComponentRepository, NavSubComponentRepository>();
            services.AddScoped<INavTitleComponentRepository, NavTitleComponentRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INoticeComponentRepository, NoticeComponentRepository>();
            services.AddScoped<IOpportunityApplyFileRepository, OpportunityApplyFileRepository>();
            services.AddScoped<IOpportunityApplyRepository, OpportunityApplyRepository>();
            services.AddScoped<IOpportunityRepository, OpportunityRepository>();
            services.AddScoped<IPageAccessComponentRepository, PageAccessComponentRepository>();
            services.AddScoped<IPageMainPhotoRepository, PageMainPhotoRepository>();
            services.AddScoped<IPrivacyComponentRepository, PrivacyComponentRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectPhotoRepository, ProjectPhotoRepository>();
            services.AddScoped<ISectionLayoutContentRepository, SectionLayoutContentRepository>();
            services.AddScoped<ISafetyComponentRepository, SafetyComponentRepository>();
            services.AddScoped<ISafetyTextComponentRepository, SafetyTextComponentRepository>();
            services.AddScoped<IServicesComponentRepository, ServicesComponentRepository>();
            services.AddScoped<IServicesComponentPhotoRepository, ServicesComponentPhotoRepository>();
            services.AddScoped<ISiteConfigRepository, SiteConfigRepository>();
            services.AddScoped<ITeamComponentRepository, TeamComponentRepository>();
            services.AddScoped<IValuesComponentRepository, ValuesComponentRepository>();
            services.AddScoped<IVMVComponentRepository, VMVComponentRepository>();
            //

            //unitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //

            //inner services
            services.Configure<SmtpConfig>(Configuration.GetSection("SmtpConfig"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IFileService, FileService>();
            //

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddRouting(options => options.LowercaseUrls = true);

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/admin/account/login";
                options.AccessDeniedPath = "/admin/account/login";
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("HRPolicy",
                    policy => policy.RequireRole("HR"));
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
                app.UseExceptionHandler("/home/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=home}/{action=index}/{id?}"
                );

                routes.MapRoute(
                   name: "default",
                   template: "{lang:languages}/{controller}/{action}/{id?}",
                   defaults: new { lang = "en", controller = "home", action = "index" }
               );
            });
        }
    }
}
