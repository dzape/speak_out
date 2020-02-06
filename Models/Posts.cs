using System;
using System.Collections.Generic;

namespace speak_out.Models
{
    public partial class Posts
    {
        public int PostId { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string Post { get; set; }

        public virtual Category Category { get; set; }
        public virtual Users User { get; set; }
    }
}
