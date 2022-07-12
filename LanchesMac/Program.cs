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

builder.Services.AddTransient<ILancheRepository, LancheRepository>(); //sempre é criada uma nova instância cada vez que for necessário,
                                                                      //independentede da requisição,
                                                                      //basicamente new XXX cada vez que for necessário.
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //criada uma única instância para todas requisições. Em outras palavras,
                                                                            //é criada uma instância a primeira vez que é solicitada e todas as
                                                                            //vezes seguintes a mesma instância é usada (design patter singleton);

builder.Services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp)); //é criada uma única instância por requição. Ou seja, usando o exemplo de
                                                                  //uma aplicação Web, quando recebe uma nova requisição, por exemplo, um click num
                                                                  //botão do outro lado do navegador, é criada uma instância, onde o escopo é essa
                                                                  //requisição. Então se for necessária a dependência multiplas vezes na mesma requisição
                                                                  //a mesma instância será usada. Seria como um "Singleton para uma requisição";

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
