using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web3MusicStore.API.Models;

public class Track
{
    [Required]
    [Column(TypeName = "NVARCHAR(32)")]
    public string song_id { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(32)")]
    public string album_id { get; set; }

    [Required]
    public int track_number { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(50)")]
    public string release_date { get; set; }
    
    [Required]
    [Column(TypeName = "NVARCHAR(20)")]
    public string release_date_precision { get; set; }
}