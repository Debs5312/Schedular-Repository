using Microsoft.EntityFrameworkCore;
using Models.API.UserAPI;
using MongoDB.EntityFrameworkCore.Extensions;

namespace UserAPI.DBConnections
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToCollection("users");
        }
        public DbSet<User> Users { get; set; }
    }
}