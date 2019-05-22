using System.Text;
using enet_be.Data;
using enet_be.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using enet_be.Domain.Services;
using enet_be.Services;
using enet_be.Services.SwaggerService;

namespace enet_be
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("SqlConnection")));

            //add scoped for Repository Base service
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            //add scoped for register repository
            services.AddScoped<IRegisterService, RegisterService>();

            //add scoped for user repository
            services.AddScoped<IUserService, UserService>();

            //add scoped for login
            services.AddScoped<ILoginService, LoginService>();

            //add scoped for Post
            services.AddScoped<IPostService, PostService>();

            //add scoped for Comment
            services.AddScoped<ICommentService, CommentService>();

            //add automapper
            services.AddAutoMapper();

            //config authen for authencation middleware
            /*This will be changed in future */
            /*Just for example need time to research more about authen */
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerServiceDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerServiceDocumentation();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();

            //Allow any for CORS
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            //Use Authentication
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
