using java.util.logging;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using RisckTrack.WEB.Components;
using RisckTrack.WEB.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ProtectedSessionStorage>();

var kongGatewayUrl = "https://localhost:8443/";
var handler = new HttpClientHandler();

if (builder.Environment.IsDevelopment())
{
    handler.ServerCertificateCustomValidationCallback =
        (httpRequestMessage, cert, cetChain, policyErrors) =>
        {
            return true;
        };
}

builder.Services.AddHttpClient("AuthApi", client =>
{
    client.BaseAddress = new Uri($"{kongGatewayUrl}riskTrackerLogin/");
}).ConfigurePrimaryHttpMessageHandler(() => handler);

builder.Services.AddHttpClient("MainApi", client =>
{
    client.BaseAddress = new Uri($"{kongGatewayUrl}riskTrackerCalculations/");
}).ConfigurePrimaryHttpMessageHandler(() => handler);

builder.Services.AddHttpClient("UserCreatorAPI", client =>
{
    client.BaseAddress = new Uri($"{kongGatewayUrl}riskTrackerUCreations/");
}).ConfigurePrimaryHttpMessageHandler(() => handler);

builder.Services.AddHttpClient<ChatbotService>(client =>
{
}).ConfigurePrimaryHttpMessageHandler(() => handler);

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
