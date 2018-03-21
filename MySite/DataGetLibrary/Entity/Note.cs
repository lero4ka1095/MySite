using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGetLibrary
{
    public class Note
    {
        [Key]
        public int IdNote { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int? IdUser { get; set; }
        public User User { get; set; }

        public ICollection<Commentary> Commentaries { get; set; }

        public Note()
        {
            Commentaries = new List<Commentary>();
        }
        public Note(string Title, string Description, User User)
        {
            this.Title = Title;
            this.Description = Description;
            this.Date = DateTime.Now;
            this.User = User;
            Commentaries = new List<Commentary>();
        }
    }
}
