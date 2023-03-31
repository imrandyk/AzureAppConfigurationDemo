using ClassLibrary;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "";

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(connectionString)
           .Select(KeyFilter.Any, LabelFilter.Null)
           // Configure to reload configuration if the registered sentinel key is modified
           .ConfigureRefresh(refreshOptions =>
                refreshOptions.Register("Sentinel", true).SetCacheExpiration(TimeSpan.FromSeconds(10)))
           .UseFeatureFlags(featureFlagOptions => featureFlagOptions.CacheExpirationInterval = TimeSpan.FromSeconds(5));
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAzureAppConfiguration();
builder.Services.AddFeatureManagement();

builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Part 2
app.UseAzureAppConfiguration();

app.Run();
