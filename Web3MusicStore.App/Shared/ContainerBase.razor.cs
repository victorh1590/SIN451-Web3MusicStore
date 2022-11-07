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
using Microsoft.JSInterop;

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


namespace Web3MusicStore.App.Shared
{
  // public enum State{
  // Home = 0,
  // Product = 1
  // }

  public partial class ContainerBase : ComponentBase
  {
    [Inject]
    public IHttpClientFactory ClientFactory { get; set; } = default!;
    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;
    public IEnumerable<Album> albums = Array.Empty<Album>();
    public IEnumerable<Album> albumSelected = Array.Empty<Album>();
    // public IEnumerable<Track> tracks = Array.Empty<Track>();
    public List<Song> songs = new List<Song>();
    public int PageState { get; set; } = 0;
    private ElementReference[] memberRef { get; set; } = new ElementReference[30];

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
        var albumList = await JsonSerializer.DeserializeAsync<IEnumerable<Album>>(responseStream, new JsonSerializerOptions()
        {
          PropertyNameCaseInsensitive = true
        });

        Console.WriteLine(albumList?.First().artists_view.First());

        if (albumList != null && albumList?.Count() != 0)
        {
          albums = albumList!.ToList();
        }
      }

      StateHasChanged();
    }

    protected async Task AlbumClicked(string? albumID)
    {
      albumSelected = albums.Select(x => x).Where(x => x.album_id.Equals(albumID));
      PageState = 1;
      CancellationTokenSource tokenSource = new CancellationTokenSource();
      tokenSource.Token.ThrowIfCancellationRequested();
      tokenSource.CancelAfter(10000);

      string url = $"https://localhost:7050/Store/{albumID}/TrackList";
      var request = new HttpRequestMessage(HttpMethod.Get, url);
      var client = ClientFactory.CreateClient();
      var response = await client.SendAsync(request, tokenSource.Token).ConfigureAwait(false);

      if (response.IsSuccessStatusCode)
      {
        using var responseStream = await response.Content.ReadAsStreamAsync();
        var songsResponse = await JsonSerializer.DeserializeAsync<IEnumerable<Song>>(responseStream, new
        JsonSerializerOptions()
        {
          PropertyNameCaseInsensitive = true
        });

        var songList = songsResponse?.ToList();
        if (songList != null && songList.Count != 0)
        {
          songs = songList;
          foreach (var song in songList)
          {
            Console.WriteLine(song.song_name);
          }
        }
      }

      Console.WriteLine(albumSelected.First().name);
      Console.WriteLine(PageState.ToString());
      StateHasChanged();
    }

    public void ClickBack()
    {
      PageState = 0;
      StateHasChanged();
    }

    public async Task PlayButtonClicked(int elementRef)
    {
      // Console.WriteLine(elementRef.ToString());
      await JSRuntime.InvokeVoidAsync("disablePlayAll", memberRef[elementRef]);
      await JSRuntime.InvokeVoidAsync("enablePlayClicked", memberRef[elementRef]);
      StateHasChanged();
    }
  }
}