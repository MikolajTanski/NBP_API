using Hangfire;
using Microsoft.EntityFrameworkCore;
using NBPAPI;
using NBPAPI.Repos.CronRepo;
using NBPAPI.Repos.CronRepo.ICronRepo;
using NBPAPI.Repos.GoldRepo;
using NBPAPI.Repos.GoldRepo.IGoldRepo;
using NBPAPI.Services.CronService.ICronService;
using NBPAPI.Services.GoldServices;
using NBPAPI.Services.GoldServices.IGoldServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.AddScoped<IGetGoldFromNBPCronRepo, GetGoldFromNBPCronRepo>();
builder.Services.AddScoped<IGoldPriceRepo, GoldPriceRepo>();
builder.Services.AddScoped<IGoldPriceService, GoldPriceService>();
builder.Services.AddScoped<IGetGoldFromNBPCronService, GetGoldFromNBPCronService>();

//connection
var connectionString = builder.Configuration.GetConnectionString("DefaulConnection");
var connectionStringHF = builder.Configuration.GetConnectionString("HangfireDb");

//context
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(connectionString));

//hangFire
builder.Services.AddHangfire(configuration => configuration
    .UseSqlServerStorage(connectionStringHF));

GlobalConfiguration.Configuration
 .UseSqlServerStorage(connectionStringHF);


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
// Konfiguracja pipeline'u HTTP
app.UseHangfireServer();

app.UseHangfireDashboard("/hangfire");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
