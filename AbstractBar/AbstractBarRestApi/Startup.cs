using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AbstractBarBusinessLogic.BusinessLogics;
using AbstractBarContracts.BusinessLogicsContracts;
using AbstractBarContracts.StoragesContracts;
using AbstractBarDatabaseImplement.Implements;


namespace AbstractBarRestApi
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
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<ICocktailStorage, CocktailStorage>();
            services.AddTransient<IComponentStorage, ComponentStorage>();
            services.AddTransient<IWarehouseStorage, WarehouseStorage>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<ICocktailLogic, CocktailLogic>();
            services.AddTransient<IWarehouseLogic, WarehouseLogic>();
            services.AddTransient<IComponentLogic, ComponentLogic>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AbstractBarRestApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AbstractBarRestApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
