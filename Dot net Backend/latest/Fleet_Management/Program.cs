using Fleet_Management.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics;
using Fleet_Management.Middleware;
using Fleet_Management.Service;
using Fleet_Management.Services;
using Newtonsoft.Json.Serialization;

namespace Fleet_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();
                })
                .AddJsonOptions(options =>
                {
                    // Configure JSON options to handle circular references
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                    // Uncomment if you need to adjust max depth
                    // options.JsonSerializerOptions.MaxDepth = 32;
                });



            builder.Services.AddDbContext<FleetDbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("fleetConnection"), new MySqlServerVersion(new Version(8, 0, 21))));

              
            builder.Services.AddScoped<IStateService, StateServiceImpl>();  
            builder.Services.AddScoped<ICityService, CityServiceImpl>();  
            builder.Services.AddScoped<IAirportService, AirportServiceImpl>();
            builder.Services.AddScoped<IHubService, HubServiceImpl>();
            builder.Services.AddScoped<ICarMasterService, CarMasterServiceImpl>();
            builder.Services.AddScoped<ICarTypeMasterService, CarTypeMasterService>();
            builder.Services.AddScoped<IAddOnMasterService, AddOnMasterService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();    
            builder.Services.AddScoped<IInvoicePdfService, InvoicePdfService>();
            builder.Services.AddScoped<IBookingHeaderService,BookingHeaderService>();
            builder.Services.AddScoped<IBookingDetailService,BookingDetailService>();
            builder.Services.AddScoped<IMembershipService, MembershipService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            

            builder.Services.AddControllers();

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });


            var app = builder.Build(); // error occurs here 

            app.UseExceptionHandler(exceptionHandlerApp
                        => exceptionHandlerApp.Run(async context
                                => await context.RequestServices
                                        .GetRequiredService<IExceptionHandler>()
                                            .TryHandleAsync(context, context.Features.Get<IExceptionHandlerFeature>()?.Error!, default)));

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
