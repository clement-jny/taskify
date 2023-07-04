using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

[Table("task")]
public class Task
{
  [Key]
  [Column("id", Order = 0)]
  public int Id { get; set; }

  [Required]
  [Column("name")]
  public string Name { get; set; } = string.Empty;

  [Column("notes")]
  public string? Notes { get; set; }

  [Column("isDone")]
  public bool IsDone { get; set; } = false;

  [Column("createdAt")]
  public DateOnly CreatedAt { get; set; }

  [Column("updatedAt")]
  public DateOnly UpdatedAt { get; set; }

  /* Relationships */
  [Column("userId")]
  public int UserId { get; set; }
  public User User { get; set; } = new();
}