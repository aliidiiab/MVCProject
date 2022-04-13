using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using eCommerceApp.Repos;
using eCommerceApp.Models;
using System;
using System.Collections.Generic;

namespace eCommerceApp.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository context;
        public CategoryController(ICategoryRepository _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = context.getallCategories();

            return View(categories);
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult addCategory()
        {
            return View(new Category());
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult save_addCategory(Category category)
        {

            if (ModelState.IsValid == true)
            {
                try
                {
                    context.Insert(category);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ex", ex.Message);
                }

            }

            return View("Index", category);
        }

    }
}
