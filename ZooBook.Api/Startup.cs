using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ZooBook.Application.CommandHandlers;
using ZooBook.Application.Commands;
using ZooBook.Core.Interface;
using ZooBook.Data.Context;
using ZooBook.Data.Repository;
using ZooBook.Domain.Interface;
using ZooBook.Data;
using ZooBook.Domain.Models;
using ZooBook.Application.Queries;
using ZooBook.Application.Queries.Models;
using ZooBook.Application.QueryHandlers;

namespace ZooBook.Api
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
            
            
            services.AddOptions();
            services.AddScoped(typeof(IAsyncRepository<,>), typeof(EfRepository<,>));
            services.AddScoped<DbConnection>(c => new SqlConnection(Configuration.GetConnectionString("EmployeeRecordsDbConnection")));
            services.AddDbContext<EmployeeRecordsDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EmployeeRecordsDbConnection"));
            });
           // services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(CreateEmployeeCommand).GetTypeInfo().Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZooBook.Api", Version = "v1" });
            });
            services.AddScoped<IRequestHandler<CreateEmployeeCommand, CommonResponseDto>, CreateEmployeeCommandHandler>();
            //services.AddScoped<IRequestHandler<GetAllEmployeesQuery, List<EmployeeDto>>, GetAllEmployeesQueryHandler>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
           
            services.AddAutoMapper(typeof(ZooBook.Application.AutoMapper.AutoMapperConfiguration));
            services.AddScoped<EmployeeRecordsDbContext>();
            services.AddScoped(typeof(List<Employee>), typeof(List<Employee>));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "ZooBook.Api v1");
                    options.RoutePrefix = "swagger";
                    options.DisplayRequestDuration();
                });
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
