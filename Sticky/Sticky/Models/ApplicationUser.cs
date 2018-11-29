using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sticky.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string ApplicationUserID;
        //Any info about users here
        [PersonalData]
        public string DisplayName { get; set; }

        [PersonalData]

        public List<UserBoard> UserBoards { get; set; }

        [PersonalData]
        public List<Invite> InvitesReceived { get; set; }
    }
}
