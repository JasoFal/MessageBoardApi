using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardContext _db;

    public MessagesController(MessageBoardContext db)
    {
      _db = db;
    }

    // GET: api/messages
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> Get([FromQuery] string group, string minimumPostDate, string maximumPostDate)
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();

      if (group != null)
      {
        query = query.Where(entry => entry.Group == group);
      }

      if (minimumPostDate != null && maximumPostDate != null)
      {
        query = query.Where(entry => DateTime.Compare(entry.PostTime, DateTime.Parse(minimumPostDate)) >= 0 && DateTime.Compare(entry.PostTime, DateTime.Parse(maximumPostDate)) <= 0);
      }

      return await query.ToListAsync();
    }

    // GET: api/Message/7
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
      Message message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }
      return message;
    }

    // POST: api/messages
    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId }, message);
    }

    // PUT: http://localhost:5000/api/messages/{id}?user_name={user_name}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Message message, string user_name)
    {
      if (id != message.MessageId || user_name != message.user_name)
      {
        return BadRequest();
      }
      _db.Messages.Update(message);
      try
      {
        await _db.SaveChangesAsync();
      }
      catch
      {
        if (!MessageExists(id))
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

    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }

    // DELETE: http://localhost:5000/api/messages/{id}/?user_name={user_name}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id, string user_name)
    {
      Message message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }
      else
      {
        if (message.user_name != user_name)
        {
          return Unauthorized();
        }
        else
        {
          _db.Messages.Remove(message);
          await _db.SaveChangesAsync();
        }
      }
      return NoContent();
    }
  }
}
