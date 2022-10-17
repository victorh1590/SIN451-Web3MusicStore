using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using ServiceStack;

namespace Web3MusicStore.API.Models;

public static class SeedData
{
  public static void EnsurePopulated(IApplicationBuilder app)
  {
    StoreDbContext context = app.ApplicationServices
    .CreateScope().ServiceProvider
    .GetRequiredService<StoreDbContext>(); // Retrieves DbContext.

    if (context.Database.GetPendingMigrations().Any()) // Any pending migrations?
    {
      context.Database.Migrate();
    }
    if (!context.Albums.Any()) // Db.Empty?
    {
      var albumsPath = Path.Combine(Environment.CurrentDirectory, "Data\\musicoset_metadata\\albums.csv");
      // var albumsCsv = File.ReadAllText(albumsPath).FromCsv<List<Album>>();
      // context.Products.AddRange();
      // var path1 = ".\\Data\\musicoset_metadata\\albums.csv".MapHostAbsolutePath(); 
      // var albumsCsv = ".\\Data\\musicoset_metadata\\albums.csv".MapHostAbsolutePath()
      //   .ReadAllText().FromCsv<List<Album>>();

      var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        HeaderValidated = null,
        MissingFieldFound = null
      };
      
      using (var reader = new StreamReader(albumsPath))
      using (var csv = new CsvReader(reader, conf))
      {
        var albumsCsv = csv.GetRecords<Album>().ToList();
        albumsCsv.ForEach(x => context.Albums.Add(x));
      }
    }

    if (!context.Artists.Any()) // Db.Empty?
    {
      var albumsPath = Path.Combine(Environment.CurrentDirectory, "Data\\musicoset_metadata\\artists.csv");
      var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        HeaderValidated = null,
        MissingFieldFound = null
      };

      using (var reader = new StreamReader(albumsPath))
      using (var csv = new CsvReader(reader, conf))
      {
        var artistsCsv = csv.GetRecords<Artist>().ToList();
        artistsCsv.ForEach(x => context.Artists.Add(x));
      }
    }
    
    if (!context.Songs.Any()) // Db.Empty?
    {
      var songsPath = Path.Combine(Environment.CurrentDirectory, "Data\\musicoset_metadata\\songs.csv");
      var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        HeaderValidated = null,
        MissingFieldFound = null
      };
    
      using (var reader = new StreamReader(songsPath))
      using (var csv = new CsvReader(reader, conf))
      {
        var songsCsv = csv.GetRecords<Song>().ToList();
        songsCsv.ForEach(x => context.Songs.Add(x));
      }
    }
    
    if (!context.Releases.Any()) // Db.Empty?
    {
      var releasesPath = Path.Combine(Environment.CurrentDirectory, "Data\\musicoset_metadata\\releases.csv");
      var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        HeaderValidated = null,
        MissingFieldFound = null
      };
    
      using (var reader = new StreamReader(releasesPath))
      using (var csv = new CsvReader(reader, conf))
      {
        var releasesCsv = csv.GetRecords<Release>().ToList();
        releasesCsv.ForEach(x => context.Releases.Add(x));
      }
    }
    
    if (!context.Tracks.Any()) // Db.Empty?
    {
      var tracksPath = Path.Combine(Environment.CurrentDirectory, "Data\\musicoset_metadata\\tracks.csv");
      var conf = new CsvConfiguration(CultureInfo.InvariantCulture)
      {
        HeaderValidated = null,
        MissingFieldFound = null
      };
    
      using (var reader = new StreamReader(tracksPath))
      using (var csv = new CsvReader(reader, conf))
      {
        var tracksCsv = csv.GetRecords<Track>().ToList();
        tracksCsv.ForEach(x => context.Tracks.Add(x));
      }
    }
    
    context.SaveChanges();
  }
}

// To drop db: dotnet ef database drop --force --context StoreDbContext