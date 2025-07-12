using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using RisckTrack.WEB.Components;
using RisckTrack.WEB.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddHttpClient("ApiLogin", client =>
{
    client.BaseAddress = new Uri("https://localhost:7039/");
});

builder.Services.AddScoped<AuthService>(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    var client = factory.CreateClient("ApiLogin");
    return new AuthService(client);
});

builder.Services.AddScoped<TwoFactorService>(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    var client = factory.CreateClient("ApiLogin");
    return new TwoFactorService(client);
});

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7220/")
});

builder.Services.AddScoped<UserSessionService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AssetService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<IncidentService>();
builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<TwoFactorService>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
