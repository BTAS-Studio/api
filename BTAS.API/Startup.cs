using BTAS.API.Dto;
using BTAS.API.Repository;
using BTAS.API.Repository.Interface;
using BTAS.API.Repository.Upload;
using BTAS.Data.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wkhtmltopdf.NetCore;
using static System.Collections.Specialized.BitVector32;

namespace BTAS.API
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowCredentials()
                    //.WithHeaders(HeaderNames.ContentType, "AUSTWAY")
                );
            });

            var connectionString = Configuration.GetConnectionString(name: "ApiDb");

            services.AddDbContext<MainDbContext>(options =>
            {
                //Edited by HS on 28/06/2023
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                //options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddSwaggerGenNewtonsoftSupport();

            //IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            //services.AddSingleton(mapper);

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper();

            services.AddScoped<IRepository<tbl_addressDto>, AddressRepository>();
            services.AddScoped<IRepository<tbl_carrier_api_responseDto>, ApiResponseRepository>();
            services.AddScoped<IRepository<tbl_manifestDto>, ManifestRepository>();
            services.AddScoped<IRepository<tbl_carrier_infoDto>, CarrierInfoRepository>();
            services.AddScoped<IRepository<tbl_shipmentDto>, ShipmentRepository>();
            services.AddScoped<IRepository<tbl_servicesDto>, ServiceRepository>();
            services.AddScoped<IRepository<tbl_voyageDto>, VoyageRepository>();
            services.AddScoped<IRepository<tbl_routingDto>, RoutingRepository>();
            services.AddScoped<IRepository<tbl_receptacleDto>, ReceptacleRepository>();
            services.AddScoped<IRepository<tbl_item_skuDto>, ItemSkuRepository>();
            services.AddScoped<IRepository<tbl_client_headerDto>, ClientHeaderRepository>();
            services.AddScoped<IRepository<tbl_shippers_tracking_refDto>, ShipmentTrackingRepository>();
            services.AddScoped<IRepository<tbl_client_contact_detailDto>, ContactDetailRepository>();
            services.AddScoped<IRepository<tbl_containerDto>, ContainerRepository>();
            services.AddScoped<IRepository<tbl_barcodeDto>, BarcodeRepository>();
            services.AddScoped<IRepository<tbl_default_settingDto>, SettingsRepository>();
            //Added by HS on 12/07/2023
            services.AddScoped<IRepository<tbl_incotermDto>, IncotermRepository>();
            //Added by HS on 14/06/2023
            services.AddScoped<IRepository<tbl_note_categoryDto>, NoteCategoryRepository>();
            services.AddScoped<IRepository<tbl_noteDto>, NoteRepository>();
            services.AddScoped<IRepository<tbl_milestone_headerDto>, MilestoneHeaderRepository>();
            services.AddScoped<IRepository<tbl_milestone_linkDto>, MilestoneLinkRepository>();
            services.AddScoped<IRepository<tbl_documentDto>, DocumentRepository>();

            services.AddScoped<IAustwayLabelRepository, AustwayLabelRepository>();

            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            services.AddTransient<ApiResponseRepository>();
            services.AddTransient<ManifestRepository>();
            services.AddTransient<ShipmentRepository>();

            services.AddTransient<ApgRepository>();
            services.AddTransient<FastwayRepository>();
            services.AddTransient<BorderRepository>();
            services.AddTransient<NZRepository>();
            services.AddTransient<AmazonRepository>();
            services.AddTransient<Austway3plRepository>();
            services.AddTransient<AustwayTruckRepository>();
            services.AddTransient<AlliedRepository>();

            services.AddTransient<VoyageRepository>();
            services.AddTransient<MasterRepository>();
            services.AddTransient<HouseRepository>();
            services.AddTransient<HouseItemRepository>();
            services.AddTransient<ShipmentRepository>();
            services.AddTransient<ShipmentItemRepository>();
            services.AddTransient<RoutingRepository>();
            services.AddTransient<ReceptacleRepository>();
            services.AddTransient<ItemSkuRepository>();
            services.AddTransient<ClientHeaderRepository>();
            services.AddTransient<ShipmentTrackingRepository>();
            services.AddTransient<ContactDetailRepository>();
            services.AddTransient<ContainerRepository>();
            services.AddTransient<SettingsRepository>();
            services.AddTransient<AddressRepository>();
            services.AddTransient<TTWSClient>();
            //Added by HS on 12/07/2023
            services.AddTransient<IncotermRepository>();
            //Added by HS on 14/06/2023
            services.AddTransient<NoteCategoryRepository>();
            services.AddTransient<NoteRepository>();
            services.AddTransient<MilestoneHeaderRepository>();
            services.AddTransient<MilestoneLinkRepository>();
            services.AddTransient<DocumentRepository>();
            //services.AddSingleton<TTWS>();
            //Added by HS on 08/01/2023
            services.AddTransient<BulkUploadRepository>();
            services.AddSingleton(Configuration);
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //    builder.WithOrigins("*")
            //    .AllowAnyHeader()
            //    .AllowAnyMethod());
            //});

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new CustomDataContractResolver();
            }
            );

            services.AddApiVersioning(config =>
            {
                config.RegisterMiddleware = true;
                config.DefaultApiVersion = new ApiVersion(2, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddHttpClient();
            services.AddMicrosoftIdentityWebApiAuthentication(Configuration);
            //services.AddControllers()
            //    .AddNewtonsoftJson(options =>
            //    {
            //        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //    });

            CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
            context.LoadUnmanagedLibrary(Path.Combine(Directory.GetCurrentDirectory(), "libwkhtmltox.dll"));

            services.AddWkhtmltopdf();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            //services.AddControllers(o =>
            //{
            //    o.Conventions.Add(new ActionHidingConvention());
            //}).AddNewtonsoftJson(options =>
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "BTAS.API", Version = "v2" });
                //c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //{
                //    Description = "Austway API with OAuth2.0 Auth Code and PKCE",
                //    Name = "oauth2",
                //    Type = SecuritySchemeType.OAuth2,
                //    Flows = new OpenApiOAuthFlows
                //    {
                //        AuthorizationCode = new OpenApiOAuthFlow
                //        {
                //            AuthorizationUrl = new Uri(Configuration["AuthorizationUrl"]),
                //            TokenUrl = new Uri(Configuration["TokenUrl"]),
                //            Scopes = new Dictionary<string, string>
                //{
                //    { Configuration["ApiScope"], "read the api" }
                //}
                //        }
                //    }
                //});
                c.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        //new OpenApiSecurityScheme
                //        //{
                //        //    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                //        //},
                //        //new[] { Configuration["ApiScope"] }
                //        new OpenApiSecurityScheme {
                //            Reference = new OpenApiReference {
                //                    Type = ReferenceType.SecurityScheme,
                //                        Id = "oauth2"
                //                },
                //                Scheme = "oauth2",
                //                Name = "oauth2",
                //                In = ParameterLocation.Header
                //        },
                //        new List < string > ()
                //    }
                //});
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BTAS.API v1"));
                app.UseSwaggerUI(c =>
                {

                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "BTAS.API v2");
                    c.OAuthClientId(Configuration["OpenIdClientId"]);
                    c.OAuthClientSecret(Configuration["ClientSecret"]);
                    c.OAuthUsePkce();
                    c.OAuthScopeSeparator(" ");
                });
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");

                // custom CSS
                c.InjectStylesheet("/swagger-ui/custom.css");
                //Added by HS on 25/07/2023
                //Show more of the model by default
                //The default expansion depth for the model on the model - example section.
                c.DefaultModelExpandDepth(0);
                //The default expansion depth for models (set to -1 completely hide the models).
                c.DefaultModelsExpandDepth(-1);
                //Close all of the major nodes
                c.DocExpansion(DocExpansion.None);
            });

            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            //app.UseMiddleware<AuthenticationMiddleware>();

            //Edited by HS on 16/06/2023
            app.UseExceptionHandler("/exception");
            //app.UseExceptionHandler(
            //    new ExceptionHandlerOptions()
            //    {
            //        AllowStatusCode404Response = true,
            //        ExceptionHandlingPath = "/exception"
            //    });
            
            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseCors("AllowOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapAreaControllerRoute(
                    name: "MaintenanceArea",
                    areaName: "Maintenance",
                    pattern: "Maintenance/{controller}/{action}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "WaybillArea",
                    areaName: "Waybill",
                    pattern: "Waybill/{controller}/{action}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "CarrierArea",
                    areaName: "Carriers",
                    pattern: "Carriers/{controller}/{action}/{id?}");

                //endpoints.MapAreaControllerRoute(
                //   name: "ByReference",
                //   areaName: "Waybill",
                //   pattern: "Waybill/{controller}/{action}/{referenceNumber}");
            });
        }
    }
}
