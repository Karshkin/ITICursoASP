using CoreGram.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGram.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(s => s.Id);

            modelbuilder.Entity<User>()
                .HasOne(s => s.Profile)
                .WithOne(s => s.User)
                .HasForeignKey<UserProfile>(s => s.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelbuilder.Entity<Follower>()
                .ToTable("Followers")
                .HasKey(s => new { s.UserId, s.FollowerId });

            modelbuilder.Entity<Follower>()
                .HasOne<User>(s => s.UserFollower)
                .WithMany(s => s.UserFollowers)
                .HasForeignKey(s => s.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Follower>()
                .HasOne<User>(s => s.UserFollowing)
                .WithMany(s => s.UserFollowings)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }

        public DbSet<Follower> Followers { get; set; }
    }
}
