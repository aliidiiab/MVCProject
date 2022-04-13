using eCommerceApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eCommerceApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel role)
        {
            if (ModelState.IsValid == false)
            {
                return View(role);
            }
            IdentityRole roleModel = new IdentityRole(role.RoleName);
            IdentityResult result = await roleManager.CreateAsync(roleModel);
            if (result.Succeeded)
            {
                return View(new RoleViewModel());
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(role);

        }
    }
}
