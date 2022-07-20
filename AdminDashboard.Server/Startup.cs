using Blazored.LocalStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminDashboard.Server.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using AdminDashboard.Server.Repository.Interface;
using AdminDashboard.Server.Repository.Implementation;

namespace AdminDashboard.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices();
            services.AddHttpClient();
            services.AddBlazoredLocalStorage();
            services.AddScoped<ApiAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<ApiAuthenticationStateProvider>());
            services.AddScoped<JwtSecurityTokenHandler>();
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IFileUpload, FileUpload>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ISubRegionRepository, SubRegionRepository>();

            services.AddSingleton(_ => Configuration);
            services.AddMemoryCache();
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                    policy.RequireClaim("Admin", "true"));
                options.AddPolicy("User", policy =>
                    policy.RequireClaim("User", "true"));
                options.AddPolicy("Manager", policy =>
                  policy.RequireClaim("Manager", "true"));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
