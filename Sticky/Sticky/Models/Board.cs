using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sticky.Models
{
    public class Board
    {
        public int BoardID { get; set; }
        public string Title { get; set; }
        public string BoardType { get; set; }

        public List<Note> Notes { get; set; }

        public List<UserBoard> UserBoards {get; set;}
        //public List<ApplicationUser> Memebers { get; set; }

        public List<Invite> InvitesSent { get; set; }




        //  public ICollection<Note> Notes { get; set; }
    }
}
