using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using RisckTrack.WEB.Components;
using RisckTrack.WEB.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var kongGatewayUrl = "http://localhost:8000/";

builder.Services.AddHttpClient("AuthApi", client =>
{
    client.BaseAddress = new Uri($"{kongGatewayUrl}riskTrackerLogin/");
});

builder.Services.AddHttpClient("MainApi", client =>
{
    client.BaseAddress = new Uri($"{kongGatewayUrl}riskTrackerCalculations/");
});

builder.Services.AddHttpClient("UserCreatorAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7019/");
});
builder.Services.AddScoped<UserSessionService>();
builder.Services.AddScoped<AuthService>(sp =>
{
    var client = sp.GetRequiredService<IHttpClientFactory>().CreateClient("AuthApi");
    return new AuthService(client);
});
builder.Services.AddScoped<AssetService>(sp =>
{
    var client = sp.GetRequiredService<IHttpClientFactory>().CreateClient("MainApi");
    return new AssetService(client);
});
builder.Services.AddScoped<UserService>(sp =>
{
    var client = sp.GetRequiredService<IHttpClientFactory>().CreateClient("UserCreatorAPI");
    return new UserService(client);
});
builder.Services.AddScoped<CompanyService>(sp =>
{
    var client = sp.GetRequiredService<IHttpClientFactory>().CreateClient("MainApi");
    return new CompanyService(client);
});
builder.Services.AddScoped<IncidentService>(sp =>
{
    var client = sp.GetRequiredService<IHttpClientFactory>().CreateClient("MainApi");
    return new IncidentService(client);
});
builder.Services.AddScoped<TeamService>(sp =>
{
    var client = sp.GetRequiredService<IHttpClientFactory>().CreateClient("MainApi");
    return new TeamService(client);
});
builder.Services.AddScoped<TwoFactorService>(sp =>
{
    var client = sp.GetRequiredService<IHttpClientFactory>().CreateClient("AuthApi");
    return new TwoFactorService(client);
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
