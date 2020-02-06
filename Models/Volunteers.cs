using System;
using System.Collections.Generic;

namespace speak_out.Models
{
    public partial class Volunteers
    {
        public int VolunteerId { get; set; }
        public int? UserId { get; set; }
        public string VolunteerName { get; set; }
        public string VolunteerSurname { get; set; }
        public string VolunteerUserName { get; set; }
        public string VolunteerEmail { get; set; }
        public string VolunteerPassword { get; set; }
        public string VolunteerPhoneNumber { get; set; }

        public virtual Users User { get; set; }
    }
}
