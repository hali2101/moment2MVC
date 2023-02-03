var builder = WebApplication.CreateBuilder(args);

//lägger till för att aktivera ett mvc-mönster
builder.Services.AddControllersWithViews();

var app = builder.Build();

//aktivera för att kunna använda statiska filer
app.UseStaticFiles();

//aktivera routing
app.UseRouting();
app.MapControllerRoute(

//hur routingen ska se ut, vilken controller, action och id
name: "default",
pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
