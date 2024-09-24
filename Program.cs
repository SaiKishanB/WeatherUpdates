using AspNetCoreRateLimit;
using WeatherUpdates.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();


builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseIpRateLimiting();
app.UseAuthorization();
app.MapControllers();
app.Run();
