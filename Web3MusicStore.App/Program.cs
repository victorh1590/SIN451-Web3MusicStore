using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MetaMask.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Web3MusicStore.App.Models;

namespace Web3MusicStore.App
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);

      builder.RootComponents.Add<App>("#app");
      //builder.RootComponents.Add<HeadOutlet>("head::after");

      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
      builder.Services.AddScoped<TabStateContainer>();
      builder.Services.AddScoped<PageStateContainer>();
      builder.Services.AddHttpClient();
      // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7050/Store") });

      // builder.Services.AddHttpClient("WebAPI",
      //   client => client.BaseAddress = new Uri("https://localhost:7050/Store"))
      //     .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

      // builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
      //     .CreateClient("WebAPI"));

      builder.Services.AddMetaMaskBlazor();

      await builder.Build().RunAsync();
    }
  }
}

// "npx tailwindcss -i ./wwwroot/app.css -o ./wwwroot/css/app.min.css --watch"
