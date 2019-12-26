using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using v1.Application.Drivers.AppServices;
using v1.Application.Drivers.Profiles;
using v1.Domain.Drivers.Services;

namespace v1.API
{
    public class Startup
    {
        private string MainDbName { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MainDbName = Configuration.GetSection("MainDbName").Value;
        }
       
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            //  MongoDB
            MongoClient client = new MongoClient(Configuration.GetConnectionString(MainDbName));

            IMongoDatabase database = client.GetDatabase(MainDbName);

            services.AddScoped<IMongoDatabase>(x => client.GetDatabase(MainDbName));   

            // Service Layer
            services.Scan(scan => scan.
                        FromAssemblyOf<DriversService>()
                        .AddClasses()
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

            // AppService Layer
            services.Scan(scan => scan.
                       FromAssemblyOf<DriversAppService>()
                       .AddClasses()
                       .AsImplementedInterfaces()
                       .WithScopedLifetime());

            // AutoMapper 
            services.AddAutoMapper(typeof(DriversAppProfile));

            // Response Compression
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            #region Swagger

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            #endregion Swagger

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Configure to use Response Compression
            app.UseResponseCompression();
        }
    }
}
