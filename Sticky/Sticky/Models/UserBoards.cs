﻿using System;
using System.Collections.Generic;

namespace Sticky.Models
{
    public partial class UserBoards
    {
        public int BoardId { get; set; }
        public string Id { get; set; }
        public string TypeUser { get; set; }

        public Boards Board { get; set; }

        public AspNetUsers IdNavigation { get; set; }
    }
}
