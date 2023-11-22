using BethanysPieShop;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddDbContext<BethanysPieShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(provider =>
    ShoppingCart.GetCart(
        provider.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session,
        provider.GetRequiredService<BethanysPieShopDbContext>())
    );



var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

//app.MapDefaultControllerRoute();

app.MapControllerRoute(
    name: "categoryRoutes",
    pattern: "category/{categoryId:int}/{numberToShow:int?}",
    defaults: new { controller = "Pie", action = "CategoryList" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

DbInitializer.Seed(app);

app.UseSession();

app.Run();
