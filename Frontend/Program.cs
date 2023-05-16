var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//HttpClient
builder.Services.AddHttpClient();
builder.Services.AddSingleton<HttpClient>();


var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();