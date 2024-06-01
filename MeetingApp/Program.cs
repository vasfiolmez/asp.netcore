var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
//controller/action/(id?)
app.MapDefaultControllerRoute();


app.Run();
