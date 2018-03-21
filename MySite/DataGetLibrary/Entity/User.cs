using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGetLibrary
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public string name { get; set; }
        public DateTime DateReg { get; set; }
        public DateTime DateBirthday { get; set; }
        public string Active { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<Commentary> Commentaries { get; set; }

        public User()
        {
            Notes = new List<Note>();
            Commentaries = new List<Commentary>();
        }
        public User(string login, string password, string name, DateTime DateBirthday, string Active)
        {
            Notes = new List<Note>();
            Commentaries = new List<Commentary>();
            this.login = login;
            this.password = password;
            this.name = name;
            this.DateReg = DateTime.Now;
            this.DateBirthday = DateBirthday;
            this.Active = Active;
        }
    }
}
