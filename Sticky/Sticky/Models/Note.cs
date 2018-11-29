using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sticky.Models
{
    public partial class Note
    {
        public int NoteID { get; set; }
        //public int? BoardId { get; set; }
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

        public int BoardID { get; set; }

        [ForeignKey("BoardID")]
        public Board Board { get; set; }
    }
}
