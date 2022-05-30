using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KalimokV2.Models;

public class Comment
{
    [Required]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    [Required]
    public int PostId { get; set; }
    
    [ForeignKey("PostId")]
    public virtual Post? Post { get; set; }
    
    [Required]
    public string AuthorId { get; set; }
    
    [ForeignKey("AuthorId")]
    public virtual User? Author { get; set; }
    
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    
    public int? ParentId { get; set; }
    
    public virtual Comment? ParentComment { get; set; }
    
    public ICollection<Comment>? Replies { get; set; }
}