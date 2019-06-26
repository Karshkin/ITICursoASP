using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreGram.Models
{
    public partial class InstagramDBScaffoldContext : DbContext
    {
        public InstagramDBScaffoldContext()
        {
        }

        public InstagramDBScaffoldContext(DbContextOptions<InstagramDBScaffoldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Followers> Followers { get; set; }
        public virtual DbSet<Likes> Likes { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<PostsComments> PostsComments { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersProfiles> UsersProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=InstagramDBScaffold;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(e => e.Remark).HasMaxLength(150);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Followers>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FollowerId });

                entity.HasOne(d => d.Follower)
                    .WithMany(p => p.FollowersFollower)
                    .HasForeignKey(d => d.FollowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FollowersUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Likes>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.UserId });

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<PostsComments>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.CommentId });

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.PostsComments)
                    .HasForeignKey(d => d.CommentId);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostsComments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(20);
            });

            modelBuilder.Entity<UsersProfiles>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.UsersProfiles)
                    .HasForeignKey<UsersProfiles>(d => d.Id);
            });
        }
    }
}
