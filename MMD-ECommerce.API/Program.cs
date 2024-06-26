using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MMD_ECommerce.API.Extensions;
using MMD_ECommerce.Core;
using MMD_ECommerce.Core.Middleware;
using MMD_ECommerce.Data.Models.Users;
using MMD_ECommerce.Infrastructure;
using MMD_ECommerce.Infrastructure.Data.Contexts;
using MMD_ECommerce.Service;
using System.Text;
namespace MMD_ECommerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<MMDDataContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddInfrastructureDependencies(builder.Configuration).AddServiceDependencies().AddCoreDependencies();

            // builder.Services.AddInfrastructureDependencies().AddServiceDependencies().AddCoreDependencies().ConfigureServices(builder.Configuration);

            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<MMDDataContext>()
                .AddSignInManager<SignInManager<AppUser>>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = builder.Configuration["Token:Issuer"],
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
                            ValidateAudience = true,
                            ValidAudience = builder.Configuration["Token:Audience"],
                            ValidateLifetime = true
                        });

            builder.Services.AddSwaggerService();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //app.MigrateLoggerDatabase( );

            await DbInitializer.InitializeDbAsync(app);


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "Merchant", "Client" };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string email = "HanyKasim.Tawfik@Gmail.Com";
                string password = "P@ssw0rd12345";
                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new AppUser
                    {
                        UserName = email,
                        Email = email
                    };
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        // Log errors from result.Errors
                    }
                }
            }

            app.Run();
        }
    }
}
