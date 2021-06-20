using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Server.Services;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Server
{
    public class Startup
    {
        private IConfiguration configuration;
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opt =>
                opt.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>()
                ).AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            var conn = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(conn));
            services.AddScoped<IAccountService, AccountServiceImpl>();
            services.AddScoped<IAllPersonService, AllPersonServiceImpl>();
            services.AddScoped<ITopicService, TopicServiceImpl>();
            services.AddScoped<ISurveyService, SurveyServiceImpl>();
            services.AddScoped<IAnswerService, AnswerServiceImpl>();
            services.AddScoped<IImgService, ImgServiceImpl>();
            services.AddScoped<IPerformerService, PerformerServiceImpl>();
            services.AddScoped<ISeminarService, SeminarServiceImpl>();
            services.AddScoped<IQuestionService, QuestionServiceImpl>();
            services.AddScoped<IFaqService, FaqServiceImpl>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                ;
            });
        }
    }
}
