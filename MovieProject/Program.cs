using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.ValidationRules;
using MovieProject.Models;
using System;
using FluentValidation.AspNetCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());



//builder.Services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<MovieDBContext>();

builder.Services.AddDbContext<ContextMovieDB>();

builder.Services.AddIdentity<User, UserRole>(x =>
{
    x.Password.RequiredLength = 5; //En az kaç karakterli olmasý gerektiðini belirtiyoruz.
    x.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluðunu kaldýrýyoruz.
    x.Password.RequireLowercase = false; //Küçük harf zorunluluðunu kaldýrýyoruz.
    x.Password.RequireUppercase = false; //Büyük harf zorunluluðunu kaldýrýyoruz.
    x.Password.RequireDigit = false; //0-9 arasý sayýsal karakter zorunluluðunu kaldýrýyoruz.

    x.User.RequireUniqueEmail = true; //Email Adreslerini Tekilleþtiriyoruz.
    x.User.AllowedUserNameCharacters = "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+";

}).AddPasswordValidator<CustomPasswordValidation>()          
          .AddErrorDescriber<CustomUserValidation>().AddEntityFrameworkStores<ContextMovieDB>();



builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = new PathString("/User/Login");
    x.Cookie = new CookieBuilder
    {
        Name = "MovieProjectDB", //Oluþturulacak Cookie'yi isimlendiriyoruz.
        HttpOnly = false, //Kötü niyetli insanlarýn client-side tarafýndan Cookie'ye eriþmesini engelliyoruz.
        MaxAge = TimeSpan.FromMinutes(120), //Oluþturulacak Cookie'nin vadesini belirliyoruz.
        SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtiyoruz.
        SecurePolicy = CookieSecurePolicy.Always //HTTPS üzerinden eriþilebilir yapýyoruz.
    };
    x.SlidingExpiration = true; //Expiration süresinin yarýsý kadar süre zarfýnda istekte bulunulursa eðer geri kalan
                                //yarýsýný tekrar sýfýrlayarak ilk ayarlanan süreyi tazeleyecektir.
    x.ExpireTimeSpan = TimeSpan.FromMinutes(2); //CookieBuilder nesnesinde tanýmlanan Expiration deðerinin varsayýlan
                                                //deðerlerle ezilme ihtimaline karþýn tekrardan Cookie vadesi burada da belirtiliyor.
});

//.AddPasswordValidator<CustomPasswordValidation>().AddEntityFrameworkStores<MovieDBContext>();
//AddUserValidator<CustomUserValidation>()


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=FilmAdmin}/{action=AddMovie}/{id?}");

app.Run();
