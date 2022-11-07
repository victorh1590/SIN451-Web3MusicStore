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
  public partial class BuyConfirmation : ComponentBase
  {
    private bool ShowMyFoo { get; set; } = true;
    private void Show()
    {
      ShowMyFoo = !ShowMyFoo;
    }
  }
}