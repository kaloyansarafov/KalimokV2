using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalimokV2.Models;

public class Friendship
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FriendshipId { get; set; }
    
    [Required]
    public string User1Id {get; set;}
    
    public virtual User User1 { get; set; }
    
    [Required]
    public string User2Id {get; set;}
    
    public virtual User User2 { get; set; }

    [Required]
    public bool IsAccepted {get; set;}
}