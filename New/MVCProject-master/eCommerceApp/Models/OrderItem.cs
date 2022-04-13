using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }










    }
}
