
namespace Web3MusicStore.App.Models
{
  public class TabStateContainer
  {
    public int TabState { get; private set; }
    public string[] tabNames { get; } = new string[3] { "Store", "Owned", "Sell" };
    public event Action? OnTabChange;

    public void SetTabState(int TabState)
    {
      if (TabState >= 0 && TabState < 3)
      { 
        this.TabState = TabState;
        NotifyStateChanged();
      }
    }
    
    private void NotifyStateChanged() => OnTabChange?.Invoke();
  }
}