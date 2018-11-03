using System;
using System.Collections.Generic;

namespace Sticky.Models
{
    public partial class Notes
    {
        public int NoteId { get; set; }
        public int? OwnerBoard { get; set; }
        public int? IsArchived { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Color { get; set; }
        public string FontName { get; set; }
        public string FontColor { get; set; }
        public int? FontSize { get; set; }
        public int? Xcoor { get; set; }
        public int? Ycoor { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public DateTime? LastEdit { get; set; }

        public Boards OwnerBoardNavigation { get; set; }
    }
}
