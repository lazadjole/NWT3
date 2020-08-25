using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Biblioteka.Api.Mappers;
using Biblioteka.Database.Models;
using Biblioteka.Database.Repositories;
using Biblioteka.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;
using Biblioteka.Service;

namespace Biblioteka.Api
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
            services.AddCors();
            services.AddControllers();
            IConfigurationProvider mappingConfig = new MapperConfiguration(t => t.AddProfile(new MappingProfile()));
            services.AddSingleton(mappingConfig);
            services.AddDbContext<BibliotekaContext>(t =>
                t.UseSqlServer(Configuration["AppSettings:BibliotekaEntities"]));
            services.AddScoped<INaslovService, NaslovService>();
            services.AddScoped<IEvidencijaDugovanjaService, EvidencijaDugovanjaService>();
            services.AddScoped<IClanService, ClanService>();
            services.AddScoped<IJezikService, JezikService>();
            services.AddScoped<IVrstaService, VrstaService>();
            services.AddScoped<IJezikRepository, JezikRepository>();
            services.AddScoped<IVrstaRepository, VrstaRepository>();
            services.AddScoped<INaslovRepository, NaslovRepository>();
            services.AddScoped<IClanRepository, ClanRepository>();
            services.AddScoped<IEvidencijaDugovanjaRepository, EvidencijaDugovanjaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
