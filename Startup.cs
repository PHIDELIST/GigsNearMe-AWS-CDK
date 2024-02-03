using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GigsNearMe.Data;
using GigsNearMe.Contracts;
using GigsNearMe.Repository;
using AutoMapper;
using System.Text.Json;
using System;

namespace GigsNearMe
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            WebHostEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        private IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();

            services.AddDatabaseDeveloperPageExceptionFilter();

            SetDatabaseAndConnectionString(services);

            // Use a startup filter to programmatically run our ef migrations and ensure the db
            // is available, saving the need to run migrations from the command line or via
            // a script. While this may not be the fully recommended approach for production,
            // it suffices for this sample.
            services.AddTransient<IStartupFilter, DbMigrationStartupFilter<GigsNearMeDbContext>>();

            services.AddScoped<IGigsNearMeRepository, GigsNearMeRepository>();

            services
                .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<GigsNearMeDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        private void SetDatabaseAndConnectionString(IServiceCollection services)
            {
                var connString = Configuration.GetConnectionString("Default");
                if (WebHostEnvironment.IsDevelopment())
                {
                    //Setting connection string for local Sqlite development database
                    services.AddDbContext<GigsNearMeDbContext>(options => options.UseSqlite(connString));
                    return;
                }

                //Setting connection string for SQL Server in RDS

                const string dbsecretParameterName = "dbsecretsname";
                try
                {
                    var secretsClient = new AmazonSecretsManagerClient();
                    var response = secretsClient.GetSecretValueAsync(new GetSecretValueRequest
                    {
                        SecretId = Configuration[dbsecretParameterName]
                    }).Result;

                    var dbsecret = JsonSerializer.Deserialize<DbSecret>(response.SecretString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    var partialConnString = string.Format(connString, dbsecret.Host, dbsecret.Port);

                    var builder = new SqlConnectionStringBuilder(partialConnString)
                    {
                        UserID = dbsecret.Username,
                        Password = dbsecret.Password
                    };

                    services.AddDbContext<GigsNearMeDbContext>(options => options.UseSqlServer(builder.ConnectionString));
                }
                catch (AmazonSecretsManagerException e)
                {
                    Console.WriteLine($"Failed to read secret {Configuration[dbsecretParameterName]}, error {e.Message}, inner {e.InnerException.Message}");
                    throw;
                }
                catch (JsonException e)
                {
                    Console.WriteLine($"Failed to parse content for secret {Configuration[dbsecretParameterName]}, error {e.Message}");
                    throw;
                }
        }
    }
}
