using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web3MusicStore.App.Models;

public class Song
{
    [Key]
    [Column(TypeName = "NVARCHAR(32)")]
    public string song_id { get; set; } = default!;
	
    [Required]
    [Column(TypeName = "NVARCHAR(200)")]
    public string? song_name { get; set; }

    [Column(TypeName = "NVARCHAR(200)")]
    public string? billboard { get; set; }
    
    // [Required]
    // public Dictionary<string, string> artists { get; set; }
    [Required]
    [Column(TypeName = "LONGTEXT")]
    public string? artists { get; set; }

    public int? popularity { get; set; }

    [Column("explicit", TypeName = "BOOLEAN")]
    public bool? Explicit { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? song_type { get; set; }
}