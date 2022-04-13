using eCommerceApp.Models;
using eCommerceApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        
        private eCommerceAppEntities context;
        public UserController(eCommerceAppEntities _context)
        {
            context = _context;
        }

        public  IActionResult Index()
        {

            ViewData["Role"] = context.UserRoles.ToList();
            return View(context.Users.ToList());
        }
        

        
        public IActionResult delete(string id)
        {
            context.Users.Remove(context.Users.FirstOrDefault(i => i.Id == id));
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
