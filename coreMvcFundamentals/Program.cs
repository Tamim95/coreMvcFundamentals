using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//This is middleware for maintaining the session TM
builder.Services.AddSession(options =>

{
    //options is a property
    options.IdleTimeout = TimeSpan.FromSeconds(20);

    //because internaly it stores the data in Cookie only
    options.Cookie.HttpOnly = true;

    //
    options.Cookie.IsEssential = true;
}); //After building it,this midleware have to use in the application

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Using session management technique for Cookie middleware TM
//after the app.UseAuthorization() middleware. There have to use 
//session method.
app.UseSession();

//Tm
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
