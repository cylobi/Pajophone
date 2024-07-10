using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pajophone.AutoMapper;
using Pajophone.Data;
using Pajophone.Data.Contexts;
using Pajophone.Models;
using Pajophone.Models.Builders;
using Pajophone.Models.Factory;
using Pajophone.Models.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"), 
        new MySqlServerVersion(new Version(8,4,0))));
builder.Services.AddAutoMapper(typeof(ProductMapperProfile));
builder.Services.AddTransient<IValidator<ProductModel>, ProductValidator>();
builder.Services.AddTransient<IProductFactory, ProductFactoryByProductViewModel>();
builder.Services.AddTransient<ICategoryFactory, CategoryFactoryByProductViewModel>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    context.SeedData();
}
 

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