using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Models
{
    public class Review
    {
        [Required]
        [Key]
        public int Review_ID { get; set; }
        public string Review_Author { get; set; }
        public string Review_Body { get; set; }
    }
}
