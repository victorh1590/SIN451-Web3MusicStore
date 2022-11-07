
namespace Web3MusicStore.App.Models
{
  public class PageStateContainer
  {
    public int savedState { get; set; } = 0;
    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
  }
}