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
    public async Task<ActionResult<IEnumerable<<Message>>> Get()
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();

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

    
  }
}
