using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sticky.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserBoards = new HashSet<UserBoards>();
        }

        public string ApplicationUserID;
        //Any info about users here
        [PersonalData]
        public string DisplayName { get; set; }

        [PersonalData]
        public virtual ICollection<UserBoards> UserBoards { get; set; }

        [PersonalData]
        public ICollection<Invite> InvitesReceived { get; set; }
    }
}
