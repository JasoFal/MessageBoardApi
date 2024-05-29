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

    // GET api/messages
    [HttpGet]
    public async Task<ActionResult<IEnumerable<<Message>>> Get()
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();

      return await query.ToListAsync();
    }
  }
}
