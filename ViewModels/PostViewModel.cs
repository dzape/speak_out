using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using speak_out.Data;
using speak_out.Models;

namespace speak_out.ViewModels
{
    public class PostViewModel
    {
        //user info

        public string UserName { get; set; }

        //Post info

        public int PostId { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string Post { get; set; }

        public virtual Category Category { get; set; }
        public virtual Users User { get; set; }

        //Category info
        public string CategoryName { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
    }
}
