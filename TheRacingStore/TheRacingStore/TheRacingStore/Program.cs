using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Data_Layer.DBConnections;
using Logic_Layer.Managers;
using Logic_Layer.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "SubwayCookie";
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
        {
            options.LoginPath = new PathString("/path-to-login");

        }
    );


builder.Services.AddSingleton<IUserDB>(new UserDB());
builder.Services.AddSingleton<IProductDB>(new ProductDB());
builder.Services.AddSingleton<IOrderDB>(new OrderDB());

IProductDB _productDB = new ProductDB();
IUserDB _userDB = new UserDB();
IOrderDB _orderDB = new OrderDB();

builder.Services.AddSingleton<IProductManager>(new ProductManager(_productDB));
builder.Services.AddSingleton<IUserManager>(new UserManager(_userDB));
builder.Services.AddSingleton<IOrderManager>(new OrderManager(_orderDB));



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

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
