using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class ViberUsersContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ViberUsers;Trusted_Connection=True;");
        }

        public ViberUsersContext(){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(i => i.IdViber);
        }
    }
}
