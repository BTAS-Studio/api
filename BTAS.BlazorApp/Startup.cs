using Blazor.AdminLte;
using BlazorTable;
using BTAS.BlazorApp;
using BTAS.BlazorApp.Services;
using BTAS.BlazorApp.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BTAS.BlazorApp
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
            services.AddHttpClient("BTASClient").ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

            });

            services.AddHttpClient<IClientHeaderService, ClientHeaderService>();
            services.AddHttpClient<IContactDetailsService, ContactDetailsService>();
            services.AddHttpClient<IIncotermsService, IncotermsService>();
            services.AddHttpClient<IMawbService, MawbService>();
            services.AddHttpClient<IHawbService, HawbService>();
            services.AddHttpClient<IContainerService, ContainerService>();

            SD.ShipmentApiBase = Configuration["ServiceUrls:ShipmentApi"];
            SD.ServiceApiBase = Configuration["ServiceUrls:ServiceApi"];
            SD.CarrierInfoApiBase = Configuration["ServiceUrls:CarrierInfoApi"];
            SD.FreightApiBase = Configuration["ServiceUrls:FreightApi"];
            SD.MawbApiBase = Configuration["ServiceUrls:MawbApi"];
            SD.HawbApiBase = Configuration["ServiceUrls:HawbApi"];
            SD.ContainerApiBase = Configuration["ServiceUrls:ContainerApi"];
            SD.AddressBookApiBase = Configuration["ServiceUrls:AddressBookApi"];
            SD.ContactDetailsApiBase = Configuration["ServiceUrls:ContactDetailsApi"];
            SD.IncotermsApiBase = Configuration["ServiceUrls:IncotermsApi"];
            SD.SettingsApiBase = Configuration["ServiceUrls:SettingsApi"];
            SD.FiltersApiBase = Configuration["ServiceUrls:FiltersApi"];

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAdminLte();
            services.AddBlazorTable();

            services.AddScoped<IClientHeaderService, ClientHeaderService>();
            services.AddScoped<IContactDetailsService, ContactDetailsService>();
            services.AddScoped<IIncotermsService, IncotermsService>();
            services.AddScoped<IMawbService, MawbService>();
            services.AddScoped<IHawbService, HawbService>();
            services.AddScoped<IContainerService, ContainerService>();

            services.AddSingleton<ApplicationState>();
            services.AddScoped<Container, Container>();

            services.AddMudServices();

            services.AddAuthentication("Cookies")
                .AddCookie(opt =>
                {
                    opt.Cookie.Name = "AuthCookie";
                })
                .AddMicrosoftAccount(opt =>
                {
                    opt.SignInScheme = "Cookies";
                    opt.ClientId = Configuration["MicrosoftAccountCredentials:ClientId"];
                    opt.ClientSecret = Configuration["MicrosoftAccountCredentials:ClientSecret"];
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}