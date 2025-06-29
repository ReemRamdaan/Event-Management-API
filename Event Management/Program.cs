
using Event_Management.Data;
using Microsoft.EntityFrameworkCore;
using Event_Management.Repositories;
using Event_Management.Interfaces;
using Event_Management.AutoMapperConfig;
using System.Text.Json.Serialization;
namespace Event_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<EventContext>(option=>option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("con1")));
            builder.Services.AddScoped<IEvent,EventRepo>();
            builder.Services.AddScoped<ILocation,LocationRepo>();
            builder.Services.AddScoped<IAttendance, AttendanceRepo>();
            builder.Services.AddScoped<IOrganiser, OrganiserRepo>();
            builder.Services.AddScoped<ICategory, CategoryRepo>();
            builder.Services.AddScoped<ITicket, TicketRepo>();
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig.AutoMapper));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
