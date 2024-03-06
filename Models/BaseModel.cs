using System.ComponentModel;

namespace APICrudClient.Models
{
    public class BaseModel
    {
        [DisplayName("Created By (UserId)")]
        public int createdBy { get; set; }

        [DisplayName("Created Date")]
        public DateTime createdDate { get; set; }

        [DisplayName("Updated By (UserId)")]
        public int updatedBy { get; set; }

        [DisplayName("Updated Date")]
        public DateTime updatedDate { get; set; }

    }
}
