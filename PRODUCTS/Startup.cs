using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PRODUCTS.DataBase;
using PRODUCTS.BusinessLogic;
using Services;
using PRODUCTS.Middleware;

namespace PRODUCTS
{
    public class Startup
    {
        const string SWAGGER_SECTION_SETTING_KEY = "SwaggerSettings";
        const string SWAGGER_SECTION_SETTING_TITLE_KEY = "Title";
        const string SWAGGER_SECTION_SETTING_VERSION_KEY = "Version";
        public Startup(IWebHostEnvironment env)
        {
            // "appsettings." + env.EnvironmentName + ".json"
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Business Logic
            services.AddTransient<IProductsListLogic, ProductsListLogic>();
            services.AddTransient<IProductLogic, ProductLogic>();
            // Database Layer
            //services.AddSingleton<IProductDBManager, ProductDBManager>();
            services.AddTransient<IProductListDBManager, ProductListDBManager>();

            services.AddTransient<IProductBackingService, ProductBackingService>();

            // ADDING CORS
            // 1. Update launch settings according with config
            // 2. Add this block to startup (ConfigureServices)
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.WithOrigins("*")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      );
            });
            // End CORS block

            var swaggerTitle = Configuration
                .GetSection(SWAGGER_SECTION_SETTING_KEY)
                .GetSection(SWAGGER_SECTION_SETTING_TITLE_KEY);
            var swaggerVersion = Configuration
                .GetSection(SWAGGER_SECTION_SETTING_KEY)
                .GetSection(SWAGGER_SECTION_SETTING_VERSION_KEY);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc
                (
                    swaggerVersion.Value, 
                    new Microsoft.OpenApi.Models.OpenApiInfo() 
                    { 
                        Title = swaggerTitle.Value, 
                        Version = swaggerVersion.Value
                    }
                );
            });
           

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandlerMiddleware();
            //app.UseHsts();
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();
            app.UseCors("AllowAll");

            app.UseAuthorizationMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Inyeccion al final, no afecta a la logica, por tal razon va al final
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PRODUCTS");
            });
        }
    }
}
