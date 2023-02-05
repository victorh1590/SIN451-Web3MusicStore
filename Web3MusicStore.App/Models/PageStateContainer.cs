
namespace Web3MusicStore.App.Models
{
  public class StateContainer
  {
    public int PageState { get; private set; } = 0;
    
    public IEnumerable<Album> albums { get; private set; } = Array.Empty<Album>();
    
    public IEnumerable<Album> albumSelected { get; private set; }= Array.Empty<Album>();
    
    public List<Song> songs { get; private set; } = new();
    
    public event Action? OnPageChange;
    
    public event Action? OnAlbumChange;
    
    public event Action? OnAPathChange;

    public void SetPageState(int num)
    {
      PageState = num;
      NotifyPageChanged();
    }

    public void SetAlbums(IEnumerable<Album> albums)
    {
      this.albums = albums;
      NotifyAlbumChanged();
    }
    
    public void SetAlbumSelected(IEnumerable<Album> albumSelected)
    {
      this.albumSelected = albumSelected;
      NotifyPageChanged();
    }
    
    public void SetSongs(List<Song> songs)
    {
      this.songs = songs;
      NotifyPageChanged();
    }

    
    private void NotifyPageChanged() => OnPageChange?.Invoke();
    
    private void NotifyAlbumChanged() => OnAlbumChange?.Invoke();
  }
}