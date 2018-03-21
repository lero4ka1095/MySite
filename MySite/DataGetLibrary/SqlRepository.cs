using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGetLibrary
{
    public partial class SqlRepository : IRepository
    {
        public DatabaseContext Db { get; set; }

        public SqlRepository()
        {
            Db = new DatabaseContext();
        }
    }
}
