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
            services.AddControllers();
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
;            });
        }
    }
}
