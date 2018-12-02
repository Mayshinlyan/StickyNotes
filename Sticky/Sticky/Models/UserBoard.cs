using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sticky.Models
{
    
    public partial class UserBoard //An entity class for the join table mapping two seperate one to many relationships (Boards and Users)
    {
        
        public int UserBoardID { get; set; }

        //public int BoardForeignKey { get; set; }
        //[ForeignKey("BoardForeignKey")]
        public int BoardID;
        public virtual Board Board { get; set; }
        public string TypeUser { get; set; }

        //public string ApplicationUserForeignKey { get; set; } //Or IdentityUserID??
        //[ForeignKey("ApplicationUserForeignKey")]
        public string ApplicationUserID;
        public virtual ApplicationUser ApplicationUser { get; set; }

       
        
    }
}
