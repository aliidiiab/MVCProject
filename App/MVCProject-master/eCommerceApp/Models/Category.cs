using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}
