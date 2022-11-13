using AutoMapper;
using Blazor.Starter.Server.Interfaces;
using Blazor.Starter.Server.Middleware;
using Blazor.Starter.Server.Models;
using Blazor.Starter.Server.Profiles;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "Open",
        builder => builder.AllowAnyOrigin().AllowAnyHeader());
});

builder.Services.AddDbContext<IExampleDbContext, ExampleDbContext>(options =>
{
    options.UseSqlite($"Data Source={builder.Configuration.GetConnectionString("ExampleDb")}");
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new DefaultProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("Open");
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseExampleMiddleware();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
