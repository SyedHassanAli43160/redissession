using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var redisConfigurationOptions = ConfigurationOptions.Parse("Hassanredis.redis.cache.windows.net:6380,password=TzsnnYnlE9AuCTMIwALcGagZP7BRxeCoAAzCaC1oaio=,ssl=True,abortConnect=False");

builder.Services.AddStackExchangeRedisCache(redisCacheConfig =>
{
    redisCacheConfig.ConfigurationOptions = redisConfigurationOptions;
});

builder.Services.AddSession(options => {
    options.Cookie.Name = "myapp_session";
    options.IdleTimeout = TimeSpan.FromMinutes(60 * 24);
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
