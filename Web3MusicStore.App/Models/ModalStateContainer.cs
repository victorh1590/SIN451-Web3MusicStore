
namespace Web3MusicStore.App.Models
{
  public class ModalStateContainer
  {
    public bool ModalState { get; private set; } = false;

    public event Action? OnModalChange;

    public void SetModalState(bool state)
    {
      ModalState = state;
      NotifyModalChange();
    }

    public void ToggleState()
    {
      ModalState = !ModalState;
      NotifyModalChange();
    }
    
    private void NotifyModalChange() => OnModalChange?.Invoke();
  }
}