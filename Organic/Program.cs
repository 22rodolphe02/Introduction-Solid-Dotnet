

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Organic.Data;
using Organic.Repository.Interface;
using Organic.Repository.Produit;
using Organic.Repository.Produit.Interface;
using Organic.Repository.Seed;
using Organic.Services.Core;
using Organic.Services.Produit;
using Organic.Services.Produit.Interface;
using Organic.Services.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

/*containerBuilder.RegisterType<ProduitViewService>().As<IProduitSearchService>();
containerBuilder.RegisterType<ProduitAdvancedSearchService>().As<IProduitSearchService>().Named<IProduitSearchService>("advanced");*/

// var container = containerBuilder.Build();

// Création d'un nouveau fournisseur de services basé sur AutoFac
// var serviceProvider = new AutofacServiceProvider(container);

/*builder.Services
    .AddSingleton<IServiceProviderFactory<ContainerBuilder>>(new AutofacServiceProviderFactory())
    .AddSingleton<IServiceProvider>(serviceProvider);*/

builder.Services
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>))
    .AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>))
    .AddScoped<IProduitViewRepos, ProduitViewRepos>()
    .AddScoped(typeof(IViewService<>), typeof(ViewService<>))
    .AddScoped<IProduitViewService, ProduitViewService>()
    .AddScoped<ProduitAdvancedSearchService>()
    .AddScoped<ProduitViewService>()
    .AddScoped(typeof(IProduitSearchFactory<>), typeof(ProduitSearchFactory<>))
    .AddScoped(typeof(IRepository<>), typeof(Repository<>));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

