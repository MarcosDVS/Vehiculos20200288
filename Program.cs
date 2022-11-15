using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Vehiculo20200288.Data;
using Vehiculo20200288.Data.Context;
using Vehiculo20200288.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IVehiculoService,VehiculoService>();
builder.Services.AddSingleton<WeatherForecastService>();

//Codigo necesario para MyDb.sqlite
builder.Services.AddSqlite<VEHICULO20200288DbContext>("Data Source=.//Data//Context//VEHICULO20200288.sqlite");
builder.Services.AddScoped <IVEHICULO20200288DbContext,VEHICULO20200288DbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//Codigo necesario para MyDb.sqlite
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<VEHICULO20200288DbContext>();
    if (db.Database.EnsureCreated())
    {
        
    }
}

app.Run();
