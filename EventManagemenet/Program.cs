using Microsoft.EntityFrameworkCore;
using EventManagemenetApp.EntityFramework;
using EventManagemenetApp.DataAccess.Interface;
using EventManagemenetApp.DataAccess.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("EventDb")));

builder.Services.AddTransient<ILogin, LoginServices>();
builder.Services.AddTransient<IRegistration, RegistrationServices>();
builder.Services.AddTransient<IRoles, RolesServices>();
builder.Services.AddTransient<ICity, CityServices>();
builder.Services.AddTransient<IState, StateServices>();
builder.Services.AddTransient<ICountry, CountryServices>();
builder.Services.AddTransient<IVenue, VenueServices>();
builder.Services.AddTransient<IEquipment, EquipmentServices>();
builder.Services.AddTransient<IFood, FoodServices>();
builder.Services.AddTransient<IDishtypes, DishtypesServices>();
builder.Services.AddTransient<ILight, LightServices>();
builder.Services.AddTransient<IFlower, FlowerServices>();
builder.Services.AddTransient<IBookingVenue, BookingVenueServices>();
builder.Services.AddTransient<IEvent, EventServices>();
builder.Services.AddTransient<IBookEquipment, BookEquipmentServices>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout as needed
    options.Cookie.HttpOnly = true;
    options.Cookie.Name = ".EventCore";
});
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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
