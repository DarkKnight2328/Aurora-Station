using Microsoft.EntityFrameworkCore;
using AuroraStationApp.Models; // Assicurati di sostituire con lo spazio dei nomi corretto

var builder = WebApplication.CreateBuilder(args);

// Configura la connessione al database prima di creare l'applicazione
builder.Services.AddDbContext<AuroraStationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuroraStationContext")));

// Aggiungi i controller con le viste
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura la pipeline delle richieste HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
