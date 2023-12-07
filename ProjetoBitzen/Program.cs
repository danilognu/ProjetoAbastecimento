using ProjetoBitzen.Data;
using ProjetoBitzen.Models;
using ProjetoBitzen.Persistencia;
using ProjetoBitzen.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<IDapperContext, DapperContext>();
builder.Services.AddTransient<IMotoristaRepository, MotoristaRepository>();
builder.Services.AddTransient<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddTransient<IAbastecimentoRepository, AbastecimentoRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

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
