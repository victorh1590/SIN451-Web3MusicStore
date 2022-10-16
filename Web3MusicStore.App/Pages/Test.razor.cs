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
using System.Threading;
using System.Diagnostics;

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
  // public enum State{
  //   Home = 0,
  //   Product = 1
  // }

  public partial class Test
  {
    [Inject]
    IHttpClientFactory ClientFactory { get; set; } = default!;
    public IEnumerable<Product> products = Array.Empty<Product>();
    public int PageState { get; set; } = 0;
    
    protected override async Task OnInitializedAsync()
    {
      CancellationTokenSource tokenSource = new CancellationTokenSource();
      tokenSource.Token.ThrowIfCancellationRequested();
      tokenSource.CancelAfter(10000);

      var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7050/Store");
      var client = ClientFactory.CreateClient();
      var response = await client.SendAsync(request, tokenSource.Token).ConfigureAwait(false);
      // var response = await client.GetAsync("https://localhost:7050/Store");

      if (response.IsSuccessStatusCode)
      {
        using var responseStream = await response.Content.ReadAsStreamAsync();
        var productList = await JsonSerializer.DeserializeAsync<IEnumerable<Product>>(responseStream, new JsonSerializerOptions()
        {
          PropertyNameCaseInsensitive = true
        });

        if (productList != null && productList?.Count() != 0)
        {
          products = productList!.ToList<Product>();
        }
      }

      StateHasChanged();
    }

    private void ProductClicked(long? productID)
    {
      products = products.Select(x => x).Where(x => x.ProductID == productID);
      PageState = 1;
      Console.WriteLine(products.First().Name);
      Console.WriteLine(PageState.ToString());
      StateHasChanged();
    }
  }
}