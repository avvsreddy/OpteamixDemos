
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductCatelogService.Api.Services;
using ProductCatelogService.Data;
using ProductCatelogService.Domain.Repositories;
using System.Text;

namespace ProductCatelogService.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddXmlSerializerFormatters().AddNewtonsoftJson();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // for swagger support
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddOData();

            // register the repository with the DI container
            builder.Services.AddScoped<IProductsRepository,ProductsRepository>();
            //builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();
            //builder.Services.AddTransient<IProductsRepository, ProductsRepository>();

            builder.Services.AddScoped<TokenService>();

     
            var key = Encoding.UTF8.GetBytes("ThisIsMySecretKey123456789fsdfsdfsdfljdfdfjdfdfker3redfdsfsdfeweqredfgdfgdfgrgqertegdgsdgdfg"); // keep this secret key in appsettings.json or environment variable or key vaults in real application 

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = "Opteamix-AuthServer",
                            ValidAudience = "Opteamix-Api-Clients",

                            IssuerSigningKey =
                                new SymmetricSecurityKey(key)
                        };
                });

            builder.Services.AddAuthorization();


            // db context registration with DI container
            builder.Services.AddDbContext<ProductsDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ProductsDbContext>()
                .AddDefaultTokenProviders();


            string corsAllowAllPolicy = "AllowAll";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(corsAllowAllPolicy, policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

           


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            // add swagger support middleware
            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(corsAllowAllPolicy);
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();
          
          

            app.UseEndpoints(endpoints => 
            {
                endpoints.EnableDependencyInjection();
                endpoints.Select()
                         .Filter()
                         .OrderBy()
                         .Count()
                         .Expand()
                         .MaxTop(100)
                         .MapControllers();
            } );

            //app.MapControllers();

            app.Run();
        }
    }
}
