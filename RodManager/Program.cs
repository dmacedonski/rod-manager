using System.Reflection;

using Microsoft.EntityFrameworkCore;

using RodManager.Providers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextFactory<DatabaseContext>(options =>
{
    string workingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? @"./";
    string databasePath = Path.Join(workingDirectory, "rod_manager.db");
    options.UseSqlite($"Data Source={databasePath}");
});
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

WebApplication app = builder.Build();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (IServiceScope scope = app.Services.CreateScope())
{
    DatabaseContext db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    db.Database.Migrate();
}

app.Run();