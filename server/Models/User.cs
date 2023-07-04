using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace server.Models;

[Table("user")]
public class User
{
  [Key]
  [Column("id", Order = 0)]
  public int Id { get; set; }

  [Required]
  [Column("lastname")]
  public string Lastname { get; set; } = string.Empty;

  [Required]
  [Column("firstname")]
  public string Firstname { get; set; } = string.Empty;

  [Required]
  [Column("email")]
  public string Email { get; set; } = string.Empty;

  [Required]
  [Column("password")]
  public string Password { get; set; } = string.Empty;

  /* Relationships */
  public List<Task> Tasks { get; set; } = new();
}