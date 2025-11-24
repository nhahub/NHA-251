using EgyptExploring.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EgyptExploring.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public RoleController(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View("AddRole");
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            IdentityRole<int> identityRole = new IdentityRole<int>();
            identityRole.Name = roleViewModel.Name;
            await _roleManager.CreateAsync(identityRole);
            return RedirectToAction("Index", "Home");
        }

    }
}
