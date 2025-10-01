using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PaymentProcessor.Web;
using YourApp.Shared.Crypto;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Explicitly load tokens.json from app root (tokens.json must be copied to output)
try
{
    var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
    using var stream = await http.GetStreamAsync("tokens.json");
    builder.Configuration.AddJsonStream(stream);
}
catch (Exception ex)
{
    Console.WriteLine($"Warning: could not load tokens.json: {ex.Message}");
}

// Bind PaymentConfig from loaded JSON and register singleton
var paymentConfig = new PaymentConfig();
builder.Configuration.GetSection("PaymentConfig").Bind(paymentConfig);
builder.Services.AddSingleton(paymentConfig);

// Register services
builder.Services.AddScoped<IPaymentValidator, EvmPaymentValidator>();

await builder.Build().RunAsync();