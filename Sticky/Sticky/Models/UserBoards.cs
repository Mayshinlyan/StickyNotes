using System;
using System.Collections.Generic;

namespace Sticky.Models
{
    public partial class UserBoards
    {
        public int BoardId { get; set; }
        public string UserName { get; set; }
        public string TypeUser { get; set; }

        public Boards Board { get; set; }
    }
}
