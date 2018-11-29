using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sticky.Models
{
    public class Invite
    {
        public int InviteID { get; set; }

        public int BoardID { get; set; }
        [ForeignKey("BoardID")]
        public Board Board { get; set; }

        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public ApplicationUser Recipient;

        
    }
}
