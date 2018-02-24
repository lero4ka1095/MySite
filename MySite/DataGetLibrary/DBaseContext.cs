using DataGetLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGetLibrary
{
    public class DBaseContext : DbContext
    {
        public DbSet<Currency> Currency { get; set; }

        protected override void Dispose(bool disposing)
        {
            this.Dispose();
            base.Dispose(disposing);
        }
    }
}
