namespace MessageBoard
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Content { get; set; }
    public string Group { get; set; }
    public DateTime PostTime { get; set; }
    public string user_name { get; set; }
  }
}