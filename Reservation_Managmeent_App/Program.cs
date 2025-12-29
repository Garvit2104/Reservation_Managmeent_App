using Microsoft.EntityFrameworkCore;
using Reservation_Managmeent_App.Data;
using Reservation_Managmeent_App.BLL.ReservationTypes;
using Reservation_Managmeent_App.DAL.ReservationTypes;
using Reservation_Managmeent_App.BLL.Reservations;
using Reservation_Managmeent_App.DAL.Reservations;
using Reservation_Managmeent_App.ClientMicroServices.Client_HR;
using Reservation_Managmeent_App.ClientMicroServices.Client_TP;
using Reservation_Managmeent_App.BLL.ReservationDocs;
using Reservation_Managmeent_App.DAL.ReservationDocs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ReservationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Reservation_db")));

builder.Services.AddScoped<IReservationTypeService, ReservationTypesService>();
builder.Services.AddScoped<IReservationTypeRepos, ReservationTypeRepos>();

builder.Services.AddScoped<IReservationService, ReservationsServiceClass>();
builder.Services.AddScoped<IReservationRepos, ReservationRepos>();

builder.Services.AddScoped<IReservationDocsService, ReservationDocsService>();
builder.Services.AddScoped<IReservationDocsRepo, ReservationDocsRepo>();

builder.Services.AddScoped<IClient_HR_Service, Client_HR_Service>();
builder.Services.AddScoped<IClient_TP_Service, Client_TP_Service>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("HumanResource", client =>
{
    client.BaseAddress = new Uri("https://localhost:7260/");
});

builder.Services.AddHttpClient("TravelPlanner", client =>
{
    client.BaseAddress = new Uri("https://localhost:7221/");
    
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
