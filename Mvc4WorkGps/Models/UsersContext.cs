using System.Data.Entity;

namespace Mvc4WorkGps.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<WorkRecordModel> WorkRecords { get; set; }
    }
}