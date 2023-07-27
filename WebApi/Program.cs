using Application;
using Infrastructure;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddCors(o =>
                o.AddPolicy("BlazorWasmApp", builder =>
                {
                    builder
                    .AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }
            ));

            builder.Services.AddMvc().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddControllers();

            builder.Services.AddApplicationLayerServices();
            builder.Services.AddInfrastructureLayerServices(builder.Configuration);
            builder.Services.GetApplicationSettings(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Files")),
                RequestPath = new PathString("/Files")
            });

            app.UseHttpsRedirection();

            app.UseCors("BlazorWasmApp");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}