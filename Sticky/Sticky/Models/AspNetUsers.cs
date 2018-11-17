using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Sticky.Models
{
    public partial class AspNetUsers : IdentityUser
    {
        public AspNetUsers()
        {

            UserBoards = new HashSet<UserBoards>();
        }

        public ICollection<UserBoards> UserBoards { get; set; }
    }
}
