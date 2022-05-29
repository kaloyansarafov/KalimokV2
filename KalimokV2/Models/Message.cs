using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalimokV2.Models;

public class Message
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string MessageText { get; set; }
    
    [Required]
    public DateTime MessageDate { get; set; }
    
    [Required]
    public string SenderId { get; set; }
    
    [ForeignKey("SenderId")]
    public virtual User Sender { get; set; }

    [Required]
    public string ReceiverId { get; set; }

    [ForeignKey("ReceiverId")]
    public virtual User Receiver { get; set; }
}