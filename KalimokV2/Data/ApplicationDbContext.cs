using KalimokV2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KalimokV2.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Message>()
            .HasKey(p => p.Id);

        builder.Entity<Message>()
            .Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Entity<User>()
            .Property(b => b.AvatarUrl)
            .HasDefaultValue("no_profile_image.png");

        builder.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.AuthorId);

        builder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(p => p.Post)
            .HasForeignKey(p => p.PostId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Comment>()
            .HasOne(p => p.Author)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.AuthorId);

        builder.Entity<Comment>()
            .HasMany(p => p.Replies)
            .WithOne(p => p.ParentComment)
            .HasForeignKey(p => p.ParentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Friendship>()
            .HasKey(f => new { f.User1Id, f.User2Id });

        builder.Entity<Friendship>()
            .HasOne(f => f.User1)
            .WithMany()
            .HasForeignKey(f => f.User1Id);

        builder.Entity<Friendship>()
            .HasOne(f => f.User2)
            .WithMany()
            .HasForeignKey(f => f.User2Id)
            .OnDelete(DeleteBehavior.NoAction);
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Friendship> Friendships { get; set; }
    public DbSet<Message> Messages { get; set; }
}