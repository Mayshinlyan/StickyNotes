using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sticky.Models
{
    public partial class Board
    {
        public Board()
        {
            UserBoards = new HashSet<UserBoard>();
            Notes = new HashSet<Note>();
        }

        public int BoardID { get; set; }
        public string Title { get; set; }
        public string BoardType { get; set; }

        public ICollection<Note> Notes { get; set; }

        public ICollection<UserBoard> UserBoards {get; set;}
        //public List<ApplicationUser> Memebers { get; set; }

        public ICollection<Invite> InvitesSent { get; set; }




        //  public ICollection<Note> Notes { get; set; }
    }
}
