using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using TechPartsWebSite.Controllers;
using TechPartsWebSite.Controllers.Interfaces;
using TechPartsWebSite.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// for MySQl Connection
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(5, 7, 38));

builder.Services.AddScoped<IStkExistenciumController, StkExistenciumController>();
builder.Services.AddScoped<IStkFamiliumController, StkFamiliumController>();
builder.Services.AddScoped<IStkItemController, StkItemController>();
builder.Services.AddScoped<IStkPrecioController, StkPrecioController>();

//Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<dariodbContext>(options => options.UseMySql(connString, serverVersion)
    // The following three options help with debugging, but should
    // be changed or removed for production.
    .LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors());

//builder.Services.AddTransient<IStkExistenciumController, StkExistenciumController>();
//builder.Services.AddTransient<IStkFamiliumController, StkFamiliumController>();

//builder.Services.AddSingleton<IStkFamiliumController, StkFamiliumController>();
//builder.Services.AddSingleton<IStkExistenciumController, StkExistenciumController>();

//Installing AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

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

app.Run();
