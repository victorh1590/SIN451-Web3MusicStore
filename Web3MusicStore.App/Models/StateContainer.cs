
namespace Web3MusicStore.App.Models
{
  public class StateContainer
  {
    public string[] savedState { get; set; } = new string[3];
    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
  }
}