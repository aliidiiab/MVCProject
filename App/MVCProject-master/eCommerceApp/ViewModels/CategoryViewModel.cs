using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public string CategoryName { get; set; }
        
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
