﻿using System.Configuration;
using CMVC.DataAccess.Context;
using CMVC.DataAccess.Repository;
using CMVC.DataAccess.Repository.IRepository;
using CMVC.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton<ISingletionGuidService,SingletionGuidService>();
//builder.Services.AddScoped<IScopedGuidServices,ScopedGuidService>();
//builder.Services.AddTransient<ITransientGuidService,TransientGuidService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

//SetUp and Register DB
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnect")));

//builder.Services.AddSingleton();
//builder.Services.AddRazorPages()
//    .AddRazorRuntimeCompilation();
var mvcBuilder = builder.Services.AddRazorPages();
if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

