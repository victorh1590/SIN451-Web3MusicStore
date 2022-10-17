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

//    [Column(TypeName = "NVARCHAR(200)")]
//    public string? billboard { get; set; }
    
    // [Required]
    // public Dictionary<string, string> artists { get; set; }
    [Required]
    [Column(TypeName = "NVARCHAR(400)")]
    public string id_artists { get; set; }
	
	[Required]
    [Column(TypeName = "NVARCHAR(600)")]
    public string name_artists { get; set; }

    public int? popularity { get; set; }

    [Column(TypeName = "NVARCHAR(50)")]
    public string? song_type { get; set; }
}