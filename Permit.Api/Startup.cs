using Article.Service.Map;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Permit.Model.Context;
using Permit.Model.Entities;
using Permit.Repository;
using Permit.Service.FluentValidations;
using Permit.Services;
using Permit.Services.DTOs;
using Permit.Services.FluentValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Permit.Api
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
            services.AddControllers();
            services.AddDbContext<PermitDbContext>(options => options.UseMySql(Configuration.GetConnectionString("Connection")));

            services.AddScoped<IBaseRepository<Permission>,PermissionRepository>();
            services.AddScoped<IBaseRepository<PermissionType>,PermissionTypeRepository>();
            services.AddScoped<IBaseService<PermissionDTO>, PermissionService>();
            services.AddScoped<IValidator<PermissionDTO>, PermissionValidator>();
            services.AddScoped<IValidator<PermissionTypeDTO>, PermissionTypeValitador>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PermitCRUD", Version = "v1" });
            });
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<PermissionProfile>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PermitCRUD v1"));
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
