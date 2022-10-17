using Web3MusicStore.API.Models.ViewModels;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json.Linq;
using ServiceStack.Text;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Web3MusicStore.API.Models;

public class ModelViewModelConverter
{
    public AlbumViewModel AlbumViewModelConverter(Album album)
    {
        var config = new MapperConfiguration(
            cfg => cfg.CreateMap<Album, AlbumViewModel>()
                .ForMember(dest => dest.artists_view, opt => opt.Ignore()
        ));
        config.AssertConfigurationIsValid();
        var mapper = config.CreateMapper();
        var albumView = mapper.Map<AlbumViewModel>(album);

        var dict = PropStringToDictionary(album.artists);

        if (dict != null)
        {
            albumView.artists_view = dict;
        }

        return albumView;
    }

    // public ArtistIdViewModel ArtistIdViewModelConverter(album)

    private Dictionary<string, string>? PropStringToDictionary(string prop)
    {
        var json = JObject.Parse(prop);
        var dict = json.ToObject<Dictionary<string, string>>() ?? null;
        return dict;
    }
}