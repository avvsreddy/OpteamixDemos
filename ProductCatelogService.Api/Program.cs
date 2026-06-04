
using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;
using ProductCatelogService.Data;
using ProductCatelogService.Domain.Repositories;

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


            // db context registration with DI container
            builder.Services.AddDbContext<ProductsDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
