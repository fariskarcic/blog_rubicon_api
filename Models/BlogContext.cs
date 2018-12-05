using Microsoft.EntityFrameworkCore;

namespace blog_rubicon_api.Models {
    public class BlogContext : DbContext {
        public BlogContext (DbContextOptions<BlogContext> options) : base (options) {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {

            modelBuilder.Entity<Post> ()
                .HasKey (t => t.Id);

            modelBuilder.Entity<Post>()
                 .Property(t => t.Slug)
                 .IsRequired();

            modelBuilder.Entity<Post>()
                .HasMany(pt => pt.Tags);

            modelBuilder.Entity<Tag> ()
                .HasKey (t => t.Id);

            modelBuilder.Entity<Tag> ()
                .HasMany (t => t.PostTags);

            modelBuilder.Entity<PostTag> ()
                .HasKey (t => new { t.PostId, t.TagId });

            modelBuilder.Entity<PostTag> ()
                .HasOne<Post> (p => p.Post)
                .WithMany (t => t.Tags)
                .HasForeignKey (s => s.PostId);

            modelBuilder.Entity<PostTag> ()
                .HasOne<Tag> (p => p.Tag)
                .WithMany (pt => pt.PostTags)
                .HasForeignKey (s => s.TagId);
        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
        modelBuilder.Entity<MyEntity>()
            .Property(p => p.CreatedAt)
            .HasDefaultValueSql("getutcdate()");
}  */

        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
    }
}