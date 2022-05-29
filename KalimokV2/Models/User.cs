using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace KalimokV2.Models;

public class User : IdentityUser
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string AvatarUrl { get; set; }
    
    [Required]
    public bool IsOnline { get; set; }
    
    public DateTimeOffset? LastOnline { get; set; }
    
    public ICollection<Comment>? Comments { get; set; }
    
    public ICollection<Post>? Posts { get; set; }
    
    [NotMapped]
    public ICollection<Friendship>? Friendships { get; set; }
    
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
}