using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class TaskifyContext : DbContext
{
  public TaskifyContext(DbContextOptions<TaskifyContext> options) : base(options) {}


  public virtual DbSet<User> Users { get; set; } = null!;

  public virtual DbSet<Models.Task> Tasks { get; set; } = null!;
}