using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;


namespace cad_restapi
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
            // Add Access-Control-Allow-Origin so that other sites can embedd content from this site
            services.AddCors();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder => builder
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials());

            // Shows UseCors with CorsPolicyBuilder.
            /*
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            */
            app.UseMvc();
        }
    }
}
