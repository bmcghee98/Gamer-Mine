using MySqlConnector;
using VideoGameDatabase.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Connect to MySQL server database
var connection = builder.Configuration.GetConnectionString("Default") + 
    "Password:" + builder.Configuration["Connection:MySqlPassword"];


builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(connection));

builder.Services.AddScoped<CardService>();

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

app.Run();
