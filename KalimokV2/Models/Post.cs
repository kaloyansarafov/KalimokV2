using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalimokV2.Models;

public class Post
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PostId { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }
    
    [Required]
    [StringLength(2000, MinimumLength = 3)]
    public string Content { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    
    [Required]
    public string AuthorId { get; set; }
    
    [ForeignKey("AuthorId")]
    public virtual User? Author { get; set; }
    
    public ICollection<Comment>? Comments { get; set; }
}