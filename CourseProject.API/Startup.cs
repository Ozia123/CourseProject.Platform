using AutoMapper;
using CourseProject.Common.Mapping;
using CourseProject.Core.Contracts.Glossary.Models;
using CourseProject.Core.Contracts.Glossary.Queries;
using CourseProject.Core.Implementation.Glossary.QueryHandlers;
using CourseProject.Domain.EF;
using CourseProject.Infrastructure.Common;
using CourseProject.Infrastructure.Common.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CourseProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString));
            
            services.AddSingleton(ctx => 
                Common.Mapping.Configuration.GetMapperConfiguration().CreateMapper());

            services.AddScoped<IMediator, Mediator>();

            services.AddScoped<IAsyncQueryHandler<FindInGlossaryQuery, GlossaryFindResultModel>, FindInGlossaryQueryHandler>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
