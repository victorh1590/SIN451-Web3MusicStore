// using Microsoft.AspNetCore.Components;
// using Web3MusicStore.App.Models;
//
// namespace Web3MusicStore.App.Shared
// {
//     public partial class ContainerNavBar : ComponentBase
//     {
//         [Inject] 
//         public StateContainer PageState { get; set; } = default!;
//         
//         public string[] tabNames { get; } = new string[3] { "Store", "Owned", "Sell" };
//         
//         protected override async Task OnInitializedAsync()
//         {
//             PageState.OnPageChange += StateHasChanged;
//             await Task.Delay(0);
//         }
//
//
//         // protected override void OnAfterRender(bool firstRender)
//         // {
//         //     if (firstRender)
//         //     {
//         //         TabStateContainer.SetTabState(0);
//         //         StateHasChanged();
//         //     }
//         // }
//
//         public async Task TabClicked(int selectedRef)
//         {
//             Console.WriteLine("Selected: " + selectedRef);
//             Console.WriteLine("Page State: " + PageState.PageState);
//
//             switch (selectedRef)
//             {
//                 case 0:
//                     PageState.SetPageState(0);
//                     break;
//                 case 1:
//                     PageState.SetPageState(1);
//                     break;
//                 case 2:
//                     PageState.SetPageState(2);
//                     break;
//             }
//
//             await InvokeAsync(StateHasChanged);
//         }
//
//         public void Dispose()
//         {
//             PageState.OnPageChange -= StateHasChanged;
//         }
//     }
// }