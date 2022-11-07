
namespace Web3MusicStore.App.Models
{
  public class TabStateContainer
  {
    public string[] savedState { get; set; } = new string[3];
    public string[] tabNames { get; } = new string[3] { "Store", "Owned", "Sell" };
    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
  }
}