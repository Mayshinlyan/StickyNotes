using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sticky.Models
{
    public partial class Invite
    {
        public int InviteID { get; set; }

        public int BoardID { get; set; }
        [ForeignKey("BoardID")]
        public Boards Board { get; set; }

        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public ApplicationUser Recipient;

        
    }
}
