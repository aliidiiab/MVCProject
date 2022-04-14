using System.Collections.Generic;
using eCommerceApp.Models;


namespace eCommerceApp.ViewModels
{
    public class HomeViewModel
    {
        public List<Review> Reviews { get; set; }
        public List<Category> Categories { get; set; }
    }
}
