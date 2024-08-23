
using LibraryAPI.Db;
using LibraryAPI.Db.IDb;
using LibraryAPI.Repository;
using LibraryAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add db context
            bool useInMemoryDb = builder.Configuration.GetValue<bool>("UseInMemoryDb");

            if(useInMemoryDb)
            {
                builder.Services.AddDbContext<InMemoryDbContext>(options => 
                    options.UseInMemoryDatabase("InMemoryDb")
                );
                builder.Services.AddScoped<IDbContext, InMemoryDbContext>();
            }
            else
            {
                builder.Services.AddDbContext<LibraryContext>(
                    ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
                );
                builder.Services.AddScoped<IDbContext, LibraryContext>();
            }
            // Add repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            });
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
