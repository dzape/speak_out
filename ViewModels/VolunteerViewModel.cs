using System.ComponentModel.DataAnnotations;

namespace speak_out.ViewModels
{
    public class VolunteerViewModel
    {
        public string VolunteerUserName { get; set; }

        [DataType(DataType.Password)]
        public string VolunteerPassword { get; set; }
    }
}
