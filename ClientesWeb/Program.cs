using ClientesWeb;
using ClientesWeb.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://clientesapp-ejf2dqc6c3cagxb6.canadacentral-01.azurewebsites.net/") 
});

builder.Services.AddScoped<IClienteService, ClienteService>();

await builder.Build().RunAsync();
