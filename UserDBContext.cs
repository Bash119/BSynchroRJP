namespace BSynchroRJP.Context
{
    using Microsoft.EntityFrameworkCore;
    using BSynchroRJP.Models;
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

    }
}
