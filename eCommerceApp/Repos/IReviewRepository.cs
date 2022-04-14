using System.Collections.Generic;
using eCommerceApp.Models;

namespace eCommerceApp.Repos
{
    public interface IReviewRepository
    {
            List<Review> GetAllReviews();
    }
}
