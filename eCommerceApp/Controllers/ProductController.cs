using Microsoft.AspNetCore.Mvc;
using eCommerceApp.Models;
using eCommerceApp.Repos;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;

namespace eCommerceApp.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository context;
        ICategoryRepository categorycontext;
        
        public ProductController(IProductRepository _context,ICategoryRepository _categorycontext)
        {
            context = _context;
            categorycontext = _categorycontext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = context.getallproducts();
            
            return View(products);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult addProduct()
        {
            List<Category> categories = categorycontext.getallCategories();
            ViewData["categories"] = categories;
            return View(new Product());
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult saveaddproduct(Product product)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    context.Insert(product);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("ex", ex.Message);
                }

            }
            
            return View("Index", product);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult editProduct(int id)
        {
            Product product = context.getbyID(id);
            return View(product);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult save_editProduct(int id,Product product)
        {
            product.ProductID = id;
            context.Update(id,product);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult deleteProduct(int id)
        {
            int flag = context.Delete(id);
            if (flag != 0)
            {
                return RedirectToAction("Index");
            }
            return View("Index");
            
        }


    }
}
