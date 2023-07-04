using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("[controller]")] // user
public class UserController : ControllerBase
{
  private readonly TaskifyContext _context;

  public UserController(TaskifyContext context)
  {
    _context = context;
  }

  // GET: user
  [HttpGet]
  public async Task<ActionResult<IEnumerable<User>>> GetUsers()
  {
    if (_context.Users == null)
    {
      return NotFound();
    }

    return await _context.Users.ToListAsync();
  }

  // GET: user/1
  [HttpGet("{id:int}")]
  public async Task<ActionResult<User>> GetUser(int id)
  {
    if (_context.Users == null)
    {
      return NotFound();
    }

    var user = await _context.Users.FindAsync(id);

    if (user == null)
    {
      return NotFound();
    }

    return user;
  }

  // PUT: user/1
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPut("{id:int}")]
  public async Task<IActionResult> PutUser(int id, User user)
  {
    if (id != user.Id)
    {
      return BadRequest();
    }

    _context.Entry(user).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!UserExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }

    return NoContent();
  }

  // POST: user
  // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  [HttpPost]
  public async Task<ActionResult<User>> PostUser(User user) //Send in JSON format
  {
    if (_context.Users == null)
    {
      return Problem("Entity set 'TaskifyContext.Users'  is null.");
    }

    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetUser", new { id = user.Id }, user);
  }

  // DELETE: user/1
  [HttpDelete("{id:int}")]
  public async Task<IActionResult> DeleteUser(int id)
  {
    if (_context.Users == null)
    {
      return NotFound();
    }

    var user = await _context.Users.FindAsync(id);

    if (user == null)
    {
      return NotFound();
    }

    _context.Users.Remove(user);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private bool UserExists(int id)
  {
    return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
  }
}