namespace Web3MusicStore.API.Models;

public interface IStoreRepository // Mediates DB/App connection.
{
  IQueryable<Album> Albums { get; } // IQueryable is cheaper than IEnumerable for querying DBs.
  IQueryable<Artist> Artists { get; }
  IQueryable<Release> Releases { get; }
  IQueryable<Song> Songs { get; }
  IQueryable<Track> Tracks { get; }
}