using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescreption { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public System.DateTime DateCreated { get; set; }
    }
}
