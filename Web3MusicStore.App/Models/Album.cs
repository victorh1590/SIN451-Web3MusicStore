using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web3MusicStore.App.Models;

public class Album
{
	[Key]
	[Column(TypeName = "NVARCHAR(32)")]
	public string album_id { get; set; } = default!;
	
    [Required]
    [Column(TypeName = "NVARCHAR(400)")]
    public string? name { get; set; }
	
    [Column(TypeName = "NVARCHAR(400)")]
    public string? billboard { get; set; }

    // [Required] 
    // public Dictionary<string, string> artists { get; set; } = new();
    [Required]
    [Column(TypeName = "LONGTEXT")]
    public string? artists { get; set; }
	
    public int? popularity { get; set; }
	
    [Required]
    public int total_tracks { get; set; }
	
    [Column(TypeName = "NVARCHAR(50)")]
    public string? album_type { get; set; }
    
    public Dictionary<string, string> artists_view { get; set; } = new();
	
    [Column(TypeName = "NVARCHAR(600)")]
    public string? image_url { get; set; }
}