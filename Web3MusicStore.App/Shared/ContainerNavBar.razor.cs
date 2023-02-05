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
        public StateContainer PageState { get; set; } = default!;
        
        public string[] tabNames { get; } = new string[3] { "Store", "Owned", "Sell" };
        
        protected override async Task OnInitializedAsync()
        {
            // TabStateContainer.OnTabChange += StateHasChanged;
            PageState.OnPageChange += StateHasChanged;
            await InvokeAsync(StateHasChanged);
        }


        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                TabStateContainer.SetTabState(0);
                StateHasChanged();
            }
        }

        public async Task TabClicked(int selectedRef)
        {
            // TabStateContainer.SetTabState(selectedRef);

            Console.WriteLine("Selected: " + selectedRef);
            Console.WriteLine("Page State: " + PageState.PageState);

            switch (selectedRef)
            {
                case 0:
                    PageState.SetPageState(0);
                    break;
                case 1:
                    PageState.SetPageState(1);
                    break;
                case 2:
                    PageState.SetPageState(2);
                    break;
            }

            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            PageState.OnPageChange -= StateHasChanged;
        }
    }
}