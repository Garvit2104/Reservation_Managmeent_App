using Microsoft.EntityFrameworkCore;
using Reservation_Managmeent_App.Data;
using Reservation_Managmeent_App.BLL.ReservationTypes;
using Reservation_Managmeent_App.DAL.ReservationTypes;
using Reservation_Managmeent_App.BLL.Reservations;
using Reservation_Managmeent_App.DAL.Reservations;
using Reservation_Managmeent_App.ClientMicroServices.Client_HR;
using Reservation_Managmeent_App.ClientMicroServices.Client_TP;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ReservationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Reservation_db")));

builder.Services.AddScoped<IReservationTypeService, ReservationTypesService>();
builder.Services.AddScoped<IReservationTypeRepos, ReservationTypeRepos>();

builder.Services.AddScoped<IReservationService, ReservationsServiceClass>();
builder.Services.AddScoped<IReservationRepos, ReservationRepos>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IClient_HR_Service, Client_HR_Service>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5238/");
});

builder.Services.AddHttpClient<IClient_TP_Service, Client_TP_Service>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5126/");
});

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
