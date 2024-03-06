using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace APICrudClient.Models
{
    public class user : BaseModel
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Username")]
        public string username { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Phone Number")]
        public string phoneNumber { get; set; }

        [DisplayName("Skillsets")]
        public string skillsets { get; set; }

        [DisplayName("Hobby")]
        public string hobby { get; set; }
    }
}