using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Web3MusicStore.App.Models;

public class Product
{
  public long? ProductID { get; set; }
  [Column(TypeName = "NVARCHAR(100)")]
  public string Name { get; set; } = String.Empty;
  [Column(TypeName = "NVARCHAR(500)")]
  public string Description { get; set; } = String.Empty;
  [Column(TypeName = "decimal(8, 2)")]
  public decimal Price { get; set; }
  [Column(TypeName = "NVARCHAR(100)")]
  public string Category { get; set; } = String.Empty;
}