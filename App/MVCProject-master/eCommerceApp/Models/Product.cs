using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Models
{
    public class Product
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

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        

    }
}
