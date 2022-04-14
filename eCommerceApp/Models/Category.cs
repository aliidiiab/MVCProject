using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string category_name{ get; set; }
        [Required]
        [MaxLength(50)]
        public string category_image{ get; set; }
    }
}
