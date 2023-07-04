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

public static class UserEndpoints
{
	public static void MapUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/User");

        group.MapGet("/", () =>
        {
            return new [] { new User() };
        })
        .WithName("GetAllUsers");

        group.MapGet("/{id}", (int id) =>
        {
            //return new User { ID = id };
        })
        .WithName("GetUserById");

        group.MapPut("/{id}", (int id, User input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateUser");

        group.MapPost("/", (User model) =>
        {
            //return TypedResults.Created($"/api/Users/{model.ID}", model);
        })
        .WithName("CreateUser");

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new User { ID = id });
        })
        .WithName("DeleteUser");
    }
}