using CarparkBookingApi.Repository.Interface.Interface;
using CarparkBookingApi.Repository.Database;
using CarparkBookingApi.Repository;
using CarparkBookingApi.Business.Interface.Interface;
using CarparkBookingApi.Business.Services;
using CarparkBookingApi.Business.Interface.Factories;
using CarparkBookingApi.Business.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDBContext, DBContext>();
//Register repositories
builder.Services.AddTransient<IParkingSlotRepository, ParkingSlotRepository>();
builder.Services.AddTransient<IAvailabilityRepository, AvailabilityRepository>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

//Register services
builder.Services.AddTransient<ICarParkObjectFactory, CarParkObjectFactory>();
builder.Services.AddTransient<IAvailabilityDataProcessor, AvailabilityDataProcessor>();
builder.Services.AddTransient<IAvailabilityService, AvailabilityService>();
builder.Services.AddTransient<IReservationService, ReservationService>();

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
