using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using TodoApp.DataAccess.Service;
using TodoApp.DataAccess.Repository;
using TodoApp.DataAccess.Model;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace TodoApp.Web
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }
        public IConfigurationRoot Configuration { get; private set; }

        //This method gets called by the runtime. Use this method to add services to the container.        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var builder = new ContainerBuilder();

            //TODO: This list of declaration should be move elsewhere if it grows bigger eventually
            builder.RegisterType<TodoItemService>().As<ITodoItemService>();
            builder.RegisterType<TodoItemMongoRepository>().As<IRepository<TodoItem, string>>()
                    .WithParameter("dataSourceConnectionString", Configuration["connectionString"])
                    .WithParameter("databaseName", Configuration["databaseName"]);

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        //This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute(); //Change for UseMvc only?
        }

        //First method to get called
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            //if (env.IsDevelopment())
            //{                
            //    builder.AddUserSecrets();
            //}

            //builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            //Configuration = config;          
        }

    }
}
