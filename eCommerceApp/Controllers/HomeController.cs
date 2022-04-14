using eCommerceApp.Models;
using eCommerceApp.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using eCommerceApp.ViewModels;

namespace eCommerceApp.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {

        IProductRepository productContext;
        ICategoryRepository categorycontext;
        IReviewRepository reviewscontext;

        public HomeController(IProductRepository _productcontext, ICategoryRepository _categorycontext, IReviewRepository _reviewscontext)
        {
            productContext = _productcontext;
            categorycontext = _categorycontext;
            reviewscontext = _reviewscontext;
        } 
        [HttpGet]
        public IActionResult Index()
        { 
            HomeViewModel HomeData = new();
            HomeData.Reviews = reviewscontext.GetAllReviews();
            HomeData.Categories = categorycontext.getallCategories();

            return View(HomeData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
