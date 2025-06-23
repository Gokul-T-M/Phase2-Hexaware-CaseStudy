
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    //endpoints.MapControllerRoute(
    //    name: "default",
    //    pattern: "{controller=Client}/{action=ShowAllClientDetails}/{id?}"

    //    );
});

app.Run();
