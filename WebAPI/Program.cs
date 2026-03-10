
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;    

namespace HotelListing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionstring = builder.Configuration.GetConnectionString("HotelListingDbConnectionString");
            builder.Services.AddDbContext<HotelListingDbContext>(options => options.UseSqlServer(connectionstring));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
