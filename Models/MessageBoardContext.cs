using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public DbSet<Message> Messages { get; set; }

    public MessageBoardContext(DbContextOptions<MessageBoardContext> options) : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //   builder.Entity<Message>()
    //     .hasData(
    //       new Message
    //   );
    // }
  }
}