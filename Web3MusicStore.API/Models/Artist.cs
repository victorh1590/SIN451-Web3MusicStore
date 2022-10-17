using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web3MusicStore.API.Models;

public class Artist {
	[Key]
	[Column(TypeName = "NVARCHAR(32)")]
	public string artist_id { get; set; }
	
	[Required]
	[Column(TypeName = "NVARCHAR(200)")]
	public string name { get; set; }
	
	public int? followers { get; set; }

	public int? popularity { get; set; }
	
	[Column(TypeName = "NVARCHAR(50)")]
	public string? artist_type { get; set; }

	[Column(TypeName = "NVARCHAR(100)")]
	public string? main_genre { get; set; }

	public string? genres { get; set; }

	[Column(TypeName = "NVARCHAR(600)")]
	public string? image_url { get; set; }
}