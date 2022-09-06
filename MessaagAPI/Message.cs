namespace MessaagAPI
{
    public class Message
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string MessageText { get; set; }
    }
}
