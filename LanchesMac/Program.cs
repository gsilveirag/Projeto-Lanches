using LanchesMac.Context;
using LanchesMac.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using LanchesMac.Repositories;
using LanchesMac.Models;

var builder = WebApplication.CreateBuilder(args);

// Cofiguracao de Conexao
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

builder.Services.AddTransient<ILancheRepository, LancheRepository>(); //sempre � criada uma nova inst�ncia cada vez que for necess�rio,
                                                                      //independentede da requisi��o,
                                                                      //basicamente new XXX cada vez que for necess�rio.
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //criada uma �nica inst�ncia para todas requisi��es. Em outras palavras,
                                                                            //� criada uma inst�ncia a primeira vez que � solicitada e todas as
                                                                            //vezes seguintes a mesma inst�ncia � usada (design patter singleton);

builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp)); //� criada uma �nica inst�ncia por requi��o. Ou seja, usando o exemplo de
                                                                  //uma aplica��o Web, quando recebe uma nova requisi��o, por exemplo, um click num
                                                                  //bot�o do outro lado do navegador, � criada uma inst�ncia, onde o escopo � essa
                                                                  //requisi��o. Ent�o se for necess�ria a depend�ncia multiplas vezes na mesma requisi��o
                                                                  //a mesma inst�ncia ser� usada. Seria como um "Singleton para uma requisi��o";

builder.Services.AddMemoryCache();
builder.Services.AddSession();


// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "categoriaFiltro",
    pattern: "Lanche/{action}/{categoria}",
    defaults: new { Controller = "Lanche", action = "List" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
