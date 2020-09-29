using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAppBot.Models;
using IApplicationLifetime = Microsoft.AspNetCore.Hosting.IApplicationLifetime;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;

namespace WebAppBot
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
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(SwaggerGenOptionsExtensions=>{
                    SwaggerGenOptionsExtensions.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "telegram bot API",
                        Description = "A simple telegram bot ASP.NET Core Web API",
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "serhii",
                            Email = string.Empty,
                            Url = new Uri("https://example.com/name"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = new Uri("https://example.com/license"),
                        }
                    });
            });
            
        }

        private IHostEnvironment env;


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApplicationLifetime lifetime)
        {
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "telegramBotAPI_V1");
                c.RoutePrefix = string.Empty;
            });
            this.env = env;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            lifetime.ApplicationStopped.Register(OnAppStopped);

            Bot.GetBotClientAsync().Wait();
        }

        public void OnAppStopped()
        {
            if(Bot.BotClient!=null)
                Bot.BotClient.DeleteWebhookAsync().Wait();
        }
    }
}
