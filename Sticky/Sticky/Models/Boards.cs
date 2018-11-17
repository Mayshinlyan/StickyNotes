﻿using System;
using System.Collections.Generic;

namespace Sticky.Models
{
    public partial class Boards
    {
        public Boards()
        {
            Notes = new HashSet<Notes>();
            UserBoards = new HashSet<UserBoards>();
        }

        public int BoardId { get; set; }
        public string Name { get; set; }
        public string BoardType { get; set; }

        public ICollection<Notes> Notes { get; set; }
        public ICollection<UserBoards> UserBoards { get; set; }
    }
}
