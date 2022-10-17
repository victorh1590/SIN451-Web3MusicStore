using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using Web3MusicStore.API.Models;
using Web3MusicStore.API.Models.ViewModels;

namespace Web3MusicStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : Controller
{
    private IStoreRepository _repository;
    public int PageSize = 4;

    public StoreController(IStoreRepository repository)
    {
        _repository = repository;
    }

    // public IActionResult Index() => View(_repository.Products); // Send products from repository to view.

    //   public ViewResult Index(int productPage = 1) 
    //     => View(_repository.Products
    //     .OrderBy(p => p.ProductID)
    //     .Skip((productPage - 1) * PageSize)
    //     .Take(PageSize));
    // }

    // public ViewResult Index(string? category, int productPage = 1) => View(new ProductsListViewModel
    // {
    // Products = _repository.Products
    // .Where(p => category == null || p.Category == category)
    // .OrderBy(p => p.ProductID)
    // .Skip((productPage - 1) * PageSize)
    // .Take(PageSize),
    // PagingInfo = new PagingInfo
    // {
    // CurrentPage = productPage,
    // ItemsPerPage = PageSize,
    // TotalItems = (category == null ? 
    // _repository.Products.Count() : _repository.Products.Where(e => e.Category == category).Count())
    // },
    // CurrentCategory = category
    // });

    [HttpGet("", Name = "GetAlbums")]
    public async Task<IActionResult> Get()
    {
        if (!_repository.Albums.Any())
        {
            return NotFound();
        }

        ModelViewModelConverter converter = new();
        List<AlbumViewModel> albumView = new();

        int itemQuantity = 20;
        Random rand = new Random();
        List<Album> result = new();
        while (itemQuantity > 0)
        {
            int toSkip = rand.Next(0, _repository.Albums.Count());
            result.Add(_repository.Albums.Skip(toSkip).Take(1).First());
            itemQuantity--;
        }

        // var result =  await result1.ToListAsync();

        result.ForEach(x => albumView.Add(converter.AlbumViewModelConverter(x)));
        
        return Ok(albumView);
    }

    [HttpGet("{album_id}", Name = "GetAlbumById")]
    public IActionResult GetById(string album_id)
    {
        var item = _repository.Albums.Select(x => x).Where(x => x.album_id == album_id);
        if (item is null)
        {
            return NotFound();
        }

        return Ok(item);
    }
    
    [HttpGet("{album_id}/TrackList", Name = "GetAlbumTrackList")]
    public async Task<IActionResult> GetTrackList(string album_id)
    {
        var item = _repository.Albums.Select(x => x).First(x => x.album_id == album_id);
        if (item is null)
        {
            return NotFound();
        }
        
        var tracks = await _repository.Tracks
            .Select(x => x)
            .Where(x => item.album_id.Equals(x.album_id)).ToListAsync<Track>();
        if (tracks is null)
        {
            return NotFound();
        }

        List<Song> songs = new();
        foreach (var track in tracks)
        {
            var albumSong = await _repository.Songs.Select(song => song).FirstAsync(song => track.song_id.Equals(song.song_id));
            if (albumSong != null) songs.Add(albumSong);
        }

        return Ok(songs);
    }
}