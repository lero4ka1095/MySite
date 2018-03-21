using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGetLibrary
{
    public class Commentary
    {
        [Key]
        public int IdCommentary { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int? IdUser { get; set; }
        public User User { get; set; }

        public int? IdNote { get; set; }
        public Note Note { get; set; }

        public Commentary()
        {

        }
        public Commentary(string Text, User User, Note Note)
        {
            this.Text = Text;
            this.Date = DateTime.Now;
            this.User = User;
            this.Note = Note;
        }
    }
}
