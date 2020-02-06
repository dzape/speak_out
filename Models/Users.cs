using System;
using System.Collections.Generic;

namespace speak_out.Models
{
    public partial class Users
    {
        public Users()
        {
            Posts = new HashSet<Posts>();
            Volunteers = new HashSet<Volunteers>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<Volunteers> Volunteers { get; set; }
    }
}
