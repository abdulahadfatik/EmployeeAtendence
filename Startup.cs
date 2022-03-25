using AuthGQL.Data;
using AuthGQL.Logics;
using AuthGQL.Resolvers;
using AuthGQL.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace AuthGQL
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthGQL", Version = "v1" });
            });

            services.AddDbContext<AuthContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AuthContext"));
            });

            services.AddDbContextFactory<AuthContext>(lifetime: ServiceLifetime.Scoped);

            services.AddScoped<IAuthLogic, AuthLogic>();

            services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));
            services
                    .AddGraphQLServer()
                    .AddQueryType<QueryResolver>()
                    .AddMutationType<MutationResolver>()
                    .AddAuthorization()
                    .AddFiltering()
                    .AddSorting();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        var tokenSettings = Configuration
                        .GetSection("TokenSettings").Get<TokenSettings>();
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidIssuer = tokenSettings.Issuer,
                            ValidateIssuer = true,
                            ValidAudience = tokenSettings.Audience,
                            ValidateAudience = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Key)),
                            ValidateIssuerSigningKey = true
                        };
                    });
            services.AddAuthorization(options => {
                options.AddPolicy("claim-policy", policy => {
                    policy.RequireClaim("LastName", new string[] { "Bhai", "" });
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthGQL v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapControllers();
            });
        }
    }
}
