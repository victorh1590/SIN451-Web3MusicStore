using MetaMask.Blazor;
using MetaMask.Blazor.Enums;
using MetaMask.Blazor.Exceptions;
using Web3MusicStore.App.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
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


namespace Web3MusicStore.App.Shared
{
  public partial class ContainerNavBar : ComponentBase
  {
    [Inject]
    public TabStateContainer TabStateContainer { get; set; } = default!;
    [Inject]
    public PageStateContainer PageState { get; set; } = default!;
    [Inject]
    public NavigationManager NavManager { get; set; } = default!;

    protected override void OnAfterRender(bool firstRender)
    {
      if (firstRender)
      {
        for (int i = 0; i < TabStateContainer.savedState.Length; i++)
        {
          TabStateContainer.savedState[i] = "";
        }
        TabStateContainer.savedState[0] = "tab-active";
        StateHasChanged();
      }
    }

    public async Task TabClicked(int selectedRef)
    {
      for (int i = 0; i < TabStateContainer.savedState.Length; i++)
      {
        TabStateContainer.savedState[i] = "";
      }
      TabStateContainer.savedState[selectedRef] = "tab-active";

      Console.WriteLine("Selected: " + selectedRef);
      Console.WriteLine("Page State: " + PageState.savedState.ToString());

      switch (selectedRef)
      {
        case 0:
          PageState.savedState = 0;
          break;
        case 1:
          // PageState.savedState = 1;
          break;
        case 2:
          PageState.savedState = 2;
          break;
        default:
          break;
      }
      StateHasChanged();
    }
  }
}