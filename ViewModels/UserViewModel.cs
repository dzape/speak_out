using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using speak_out.Models;

namespace speak_out.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}
