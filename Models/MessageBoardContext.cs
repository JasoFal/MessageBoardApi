using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
  public class MessageBoardContext : DbContext
  {
    public DbSet<Message> Messages { get; set; }

    public MessageBoardContext(DbContextOptions<MessageBoardContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Message>()
        .HasData(
          new Message { MessageId = 1, Content = "What's up", Group = "Video", user_name = "jon"},
          new Message { MessageId = 2, Content = "Not much", Group = "Video", user_name = "join"},
          new Message { MessageId = 3, Content = "The weather", Group = "Weather", user_name = "Mr.Weather"}
      );
    }
  }
}