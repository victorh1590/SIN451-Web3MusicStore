using MetaMask.Blazor;
using MetaMask.Blazor.Enums;
using MetaMask.Blazor.Exceptions;
using Web3MusicStore.App.Models;
using Microsoft.AspNetCore.Components;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.ABI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

// namespace Web3MusicStore.App.Pages
// {
//   public partial class Test : IDisposable
//   {
//     [Inject]
//     public HttpClient Http { get; set; } = default!;

//     protected override async Task OnInitializedAsync()
//     {
//       private Product[] examples;

//       try
//       {
//         examples = await Http.GetFromJsonAsync<IEnumerable<Product>>("Get");
//   }
//       catch (AccessTokenNotAvailableException exception)
//       {
//           exception.Redirect();
//       }
//     }

//     public void Dispose()
//     {
//       IMetaMaskService.AccountChangedEvent -= MetaMaskService_AccountChangedEvent;
//       IMetaMaskService.ChainChangedEvent -= MetaMaskService_ChainChangedEvent;
//     }
//   }
// }


namespace Web3MusicStore.App.Pages
{
  public partial class Test
  {
    [Inject]
    IHttpClientFactory ClientFactory { get; set; } = default!;

    private IEnumerable<Product> products = Array.Empty<Product>();

    protected override async Task OnInitializedAsync()
    {
      // try
      // {
      //   var ex1 = await WebAPI.GetFromJsonAsync<IEnumerable<Product>>("https://localhost:7050/Store");
      //   if (ex1 != null)
      //   {
      //     examples = ex1.ToList<Product>();
      //   }
      // }
      try {
      var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7050/Store");

      var client = ClientFactory.CreateClient();

      var response = await client.SendAsync(request);

      if (response.IsSuccessStatusCode)
      {
        using var responseStream = await response.Content.ReadAsStreamAsync();
        
        var productList = await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(responseStream, new JsonSerializerOptions() {
          PropertyNameCaseInsensitive = true
        });

        if (productList != null && productList?.Count() != 0)
        {
          products = productList!.ToList<Product>();
        }
      }

      StateHasChanged();
      }
      catch(Exception ex) {
        Console.Write(ex);
      }
    }
  }
}