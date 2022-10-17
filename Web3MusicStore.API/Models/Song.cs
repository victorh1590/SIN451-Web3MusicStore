using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web3MusicStore.API.Models;

public class Song {
    [Key]
    [Column(TypeName = "NVARCHAR(32)")]
    public string song_id { get; set; }
	
    [Required]
    [Column(TypeName = "NVARCHAR(200)")]
    public string song_name { get; set; }

    [Column(TypeName = "NVARCHAR(200)")]
    public string? billboard { get; set; }
    
    [Required]
    public IDictionary<string, string> artists { get; set; }

    [Required]
    [Column(TypeName = "NVARCHAR(20)")]
    public string release_date_precision { get; set; }
    
    public int? popularity { get; set; }

    [Column("explicit", TypeName = "BOOLEAN")]
    public bool? Explicit { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? song_type { get; set; }
}