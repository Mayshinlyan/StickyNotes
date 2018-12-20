using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sticky.Models
{
    /// <summary>
    /// Represents the ApplicationUser with some additional information.
    /// </summary>
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
        public ICollection<UserBoards> UserBoards { get; set; }

        [PersonalData]
        public ICollection<Invite> InvitesReceived { get; set; }
    }
}
