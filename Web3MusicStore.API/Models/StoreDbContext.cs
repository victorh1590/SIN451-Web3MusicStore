using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Web3MusicStore.API.Models;

public class StoreDbContext : DbContext
{
    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Album> Albums => Set<Album>(); // Used to query/store in DB.
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Release> Releases => Set<Release>();
    public DbSet<Song> Songs => Set<Song>();
    public DbSet<Track> Tracks => Set<Track>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Album>()
        //     .Property(b => b.artists)
        //     .HasConversion(
        //         v => JsonConvert.SerializeObject(v),
        //         v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)!);
        //
        // modelBuilder.Entity<Song>()
        //     .Property(b => b.artists)
        //     .HasConversion(
        //         v => JsonConvert.SerializeObject(v),
        //         v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v)!);
        // modelBuilder.Entity<Artist>()
        //     .Property(b => b.genres)
        //     .HasConversion(
        //         v => JsonConvert.SerializeObject(v),
        //         v => JsonConvert.DeserializeObject<List<string>>(v)!,
        //         new ValueComparer<List<string>>(
        //             (c1, c2) => c1.SequenceEqual(c2),
        //             c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
        //             c => c.ToList()));

        modelBuilder.Entity<Release>().HasKey(k => new { k.album_id, k.artist_id });

        modelBuilder.Entity<Track>().HasKey(k => new { k.song_id, k.album_id });
    }
}