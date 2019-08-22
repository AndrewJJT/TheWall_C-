    using Microsoft.EntityFrameworkCore; 
    namespace TheWall.Models
    {
        public class MyContext : DbContext
        {
            public MyContext(DbContextOptions options) : base(options) { }
            
            // "users" table is represented by this DbSet "Users"
            public DbSet<User> users {get;set;}

            public DbSet<Message> messages { get; set; }

            public DbSet<Comment> comments { get; set; }

            //TODO add another DbSet
        }
    }