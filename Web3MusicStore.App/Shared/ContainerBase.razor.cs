
// namespace Web3MusicStore.App.Pages
// {
// public partial class Test : IDisposable
// {
// [Inject]
// public HttpClient Http { get; set; } = default!;

// protected override async Task OnInitializedAsync()
// {
// private Product[] examples;

// try
// {
// examples = await Http.GetFromJsonAsync<IEnumerable<Product>>("Get");
// }
// catch (AccessTokenNotAvailableException exception)
// {
// exception.Redirect();
// }
// }

// public void Dispose()
// {
// IMetaMaskService.AccountChangedEvent -= MetaMaskService_AccountChangedEvent;
// IMetaMaskService.ChainChangedEvent -= MetaMaskService_ChainChangedEvent;
// }
// }
// }

//
// using System.Text.Json;
// using Microsoft.AspNetCore.Components;
// using Web3MusicStore.App.Models;
//
// namespace Web3MusicStore.App.Shared
// {
//   public partial class ContainerBase : ComponentBase
//   {
//     [Inject] 
//     public StateContainer PageState { get; set; } = default!;
//     [Inject]
//     public IHttpClientFactory ClientFactory { get; set; } = default!;
//
//     protected override async Task OnInitializedAsync()
//     {
//       PageState.OnPageChange += StateHasChanged;
//       await Task.Delay(0);
//       CancellationTokenSource tokenSource = new CancellationTokenSource();
//       tokenSource.Token.ThrowIfCancellationRequested();
//       tokenSource.CancelAfter(10000);
//       
//       var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7050/Store");
//       var client = ClientFactory.CreateClient();
//       var response = await client.SendAsync(request, tokenSource.Token).ConfigureAwait(false);
//       
//       if (response.IsSuccessStatusCode)
//       {
//         using var responseStream = await response.Content.ReadAsStreamAsync();
//         var albumList = await JsonSerializer.DeserializeAsync<IEnumerable<Album>>(responseStream, new JsonSerializerOptions()
//         {
//           PropertyNameCaseInsensitive = true
//         });
//       
//         Console.WriteLine(albumList?.First().artists_view.First());
//       
//         if (albumList != null && albumList?.Count() != 0)
//         {
//           PageState.SetAlbums(albumList!.ToList());
//         }
//       }
//     }
//
//     public void Dispose()
//     {
//       PageState.OnPageChange -= StateHasChanged;
//     }
//   }
// }