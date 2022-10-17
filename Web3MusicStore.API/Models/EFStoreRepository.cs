namespace Web3MusicStore.API.Models;
public class EFStoreRepository : IStoreRepository
{
  private StoreDbContext _context;
  public EFStoreRepository(StoreDbContext context)
  {
    _context = context;
  }
  public IQueryable<Album> Albums => _context.Albums;
  public IQueryable<Artist> Artists => _context.Artists;
  public IQueryable<Release> Releases => _context.Releases;
  public IQueryable<Song> Songs => _context.Songs;
  public IQueryable<Track> Tracks => _context.Tracks;
}