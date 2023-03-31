var builder = WebApplication.CreateBuilder(args);

string connectionString = "";

// Part 1 - Comment out for part 2
// Include package Microsoft.Azure.AppConfiguration.AspNetCore
// Add Azure App Configuration to the service container.
//builder.Configuration.AddAzureAppConfiguration(connectionString);

// Part 2 - Comment out for part 3
// Load configuration from Azure App Configuration with refresh
//builder.Configuration.AddAzureAppConfiguration(options =>
//{
//    options.Connect(connectionString)
//           .Select(KeyFilter.Any, LabelFilter.Null)
//           // Configure to reload configuration if the registered sentinel key is modified
//           .ConfigureRefresh(refreshOptions =>
//                refreshOptions.Register("Sentinel", true).SetCacheExpiration(TimeSpan.FromSeconds(10)));
//});

// Part 3
// Load configuration from Azure App Configuration with feature flags
//builder.Configuration.AddAzureAppConfiguration(options =>
//{
//    options.Connect(connectionString)
//           .Select(KeyFilter.Any, LabelFilter.Null)
//           // Configure to reload configuration if the registered sentinel key is modified
//           .ConfigureRefresh(refreshOptions =>
//                refreshOptions.Register("Sentinel", true).SetCacheExpiration(TimeSpan.FromSeconds(10)))
//           .UseFeatureFlags(featureFlagOptions => featureFlagOptions.CacheExpirationInterval = TimeSpan.FromSeconds(5));
//});

// Add services to the container.
builder.Services.AddRazorPages();

// Part 2
// Add Azure App Configuration middleware to the container of services.
//builder.Services.AddAzureAppConfiguration();

// Part 3
//Include package Microsoft.FeatureManagement.AspNetCore
//builder.Services.AddFeatureManagement();

// Part 1
//builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));

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
//app.UseAzureAppConfiguration();

app.Run();
