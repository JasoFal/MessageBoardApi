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
    public async Task<ActionResult<IEnumerable<Message>>> Get(string group)
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();

      if (group != null)
      {
        query = query.Where(entry => entry.Group == group);
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

    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId }, message);
    }

    // PUT: http://localhost:5000/api/messages/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Message message)
    {
      if (id != message.MessageId)
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

    // DELETE http://localhost:5000/api/messages/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
      Message message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }
      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}
