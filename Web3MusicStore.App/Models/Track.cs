using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web3MusicStore.App.Models;

public class Track
{
    [Required]
    [Column(TypeName = "NVARCHAR(32)")]
    public string song_id { get; set; } = default!;

    [Required]
    [Column(TypeName = "NVARCHAR(32)")]
    public string album_id { get; set; } = default!;

    [Required]
    public int? track_number { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(50)")]
    public string? release_date { get; set; }
    
    [Required]
    [Column(TypeName = "NVARCHAR(20)")]
    public string? release_date_precision { get; set; }
}