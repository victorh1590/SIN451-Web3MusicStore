using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web3MusicStore.API.Models;

public class Release {
    [Required]
    [ForeignKey("artist_id")]
    [Column(TypeName = "NVARCHAR(32)")]
    public string artist_id { get; set; }
	
    [Required]
    [ForeignKey("album_id")]
    [Column(TypeName = "NVARCHAR(32)")]
    public string album_id { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(50)")]
    public string release_date { get; set; }
    
    [Required]
    [Column(TypeName = "NVARCHAR(20)")]
    public string release_date_precision { get; set; }
}