using eCommerceApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace eCommerceApp.Repos
{
    public class ReviewRepository : IReviewRepository
    {
        eCommerceAppEntities context;
        public ReviewRepository(eCommerceAppEntities _context)
        {
            context = _context;
        }
        public List<Review> GetAllReviews()
        {
            return context.Reviews.ToList();
            
        }
    }
}
 