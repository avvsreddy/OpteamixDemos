
using Microsoft.AspNet.OData.Extensions;

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
