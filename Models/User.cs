using System.ComponentModel.DataAnnotations;

namespace APICrudClient.Models
{
    public class user
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string skillsets { get; set; }
        public string hobby { get; set; }
        public int createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
    }
}