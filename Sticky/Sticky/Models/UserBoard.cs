using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sticky.Models
{
    
    public class UserBoard //An entity class for the join table mapping two seperate one to many relationships (Boards and Users)
    {
        //public int ID { get; set; }

        //public int BoardForeignKey { get; set; }
        //[ForeignKey("BoardForeignKey")]
        public int BoardID;
        public Board Board { get; set; }

        //public string ApplicationUserForeignKey { get; set; } //Or IdentityUserID??
        //[ForeignKey("ApplicationUserForeignKey")]
        public string ApplicationUserID;
        public ApplicationUser ApplicationUser { get; set; }
       
        
    }
}
