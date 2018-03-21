using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGetLibrary
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(): base("DatabaseContext")
        { }
        public DbSet<Currency> Currencies { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Commentary> Commentaries { get; set; }

        protected override void Dispose(bool disposing)
        {
            this.Dispose();
            base.Dispose(disposing);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // other code 
            Database.SetInitializer<DatabaseContext>(null);
            // more code
        }
    }
}
