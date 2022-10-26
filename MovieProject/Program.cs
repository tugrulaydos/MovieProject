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
    x.Password.RequiredLength = 5; //En az ka� karakterli olmas� gerekti�ini belirtiyoruz.
    x.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunlulu�unu kald�r�yoruz.
    x.Password.RequireLowercase = false; //K���k harf zorunlulu�unu kald�r�yoruz.
    x.Password.RequireUppercase = false; //B�y�k harf zorunlulu�unu kald�r�yoruz.
    x.Password.RequireDigit = false; //0-9 aras� say�sal karakter zorunlulu�unu kald�r�yoruz.

    x.User.RequireUniqueEmail = true; //Email Adreslerini Tekille�tiriyoruz.
    x.User.AllowedUserNameCharacters = "abc�defghi�jklmno�pqrs�tu�vwxyzABC�DEFGHI�JKLMNO�PQRS�TU�VWXYZ0123456789-._@+";

}).AddPasswordValidator<CustomPasswordValidation>()          
          .AddErrorDescriber<CustomUserValidation>().AddEntityFrameworkStores<ContextMovieDB>();



builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = new PathString("/User/Login");
    x.Cookie = new CookieBuilder
    {
        Name = "MovieProjectDB", //Olu�turulacak Cookie'yi isimlendiriyoruz.
        HttpOnly = false, //K�t� niyetli insanlar�n client-side taraf�ndan Cookie'ye eri�mesini engelliyoruz.
        MaxAge = TimeSpan.FromMinutes(120), //Olu�turulacak Cookie'nin vadesini belirliyoruz.
        SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin g�nderilmemesini belirtiyoruz.
        SecurePolicy = CookieSecurePolicy.Always //HTTPS �zerinden eri�ilebilir yap�yoruz.
    };
    x.SlidingExpiration = true; //Expiration s�resinin yar�s� kadar s�re zarf�nda istekte bulunulursa e�er geri kalan
                                //yar�s�n� tekrar s�f�rlayarak ilk ayarlanan s�reyi tazeleyecektir.
    x.ExpireTimeSpan = TimeSpan.FromMinutes(2); //CookieBuilder nesnesinde tan�mlanan Expiration de�erinin varsay�lan
                                                //de�erlerle ezilme ihtimaline kar��n tekrardan Cookie vadesi burada da belirtiliyor.
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
