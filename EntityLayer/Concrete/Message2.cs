using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Message2
    {
        [Key]
        public int MessageID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        public Author SenderUser { get; set; }
        public Author ReceiverUser { get; set; }
    }
}