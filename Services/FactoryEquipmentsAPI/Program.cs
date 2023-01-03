using FactoryEquipmentsAPI.Models;
using FactoryEquipmentsAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace FactoryEquipmentsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            // Add services to the container.
           
           services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           services.AddEndpointsApiExplorer();
           services.AddSwaggerGen();
           services.AddDbContext<FactoryEquipmentContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DbContext"));
            });
            services.AddTransient<IEquipmentServices, EquipmentServices>();
            services.AddTransient<IStatusLogServices, StatusLogServices>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}