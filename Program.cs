var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var azureappconfigurationconnectionstring = "Endpoint=https://vmappconfigdemo.azconfig.io;Id=/wKs-l8-s0:DlSjWYXzAvwWlBtjUJCn;Secret=fA+/fsYxy18SW3Lya+vKM5Coljvt3MDHMoj1GHlfJcU=";

builder.Host.ConfigureAppConfiguration(app =>
{
    app.AddAzureAppConfiguration(azureappconfigurationconnectionstring);
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
