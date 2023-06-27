using Blazor.Contacts.Wasm.Repository;
using Microsoft.AspNetCore.ResponseCompression;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//inyectar conexión a bd desde el appsetting
var dbConnectionString = builder.Configuration.GetConnectionString("ConexionPredeterminada");
builder.Services.AddSingleton<IDbConnection>((sp) => new SqlConnection(dbConnectionString));


//inyectar el repositorio
builder.Services.AddScoped<IContactRepository, ContactRepository>();

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

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
