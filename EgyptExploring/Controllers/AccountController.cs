using EgyptExploring.Models;
using EgyptExploring.RepositryInterfaces;
using EgyptExploring.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EgyptExploring.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IAppUserRepository _appUserRepository;
        
        public AccountController(UserManager<AppUser>userManager , SignInManager<AppUser>signInManager , IAppUserRepository appUserRepository , RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appUserRepository = appUserRepository;
            _roleManager = roleManager;

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid) {
             var result= await  _signInManager.PasswordSignInAsync(loginViewModel.UserName
                    , loginViewModel.Password,
                    loginViewModel.RememberMe,
                    lockoutOnFailure:false
                    );
                if (result.Succeeded)
                {  
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut) {
                   
                    ModelState.AddModelError("", "Your Email Is Locked out please Contact Us.");
                    return View(loginViewModel);
                }
                    
                    }
            ModelState.AddModelError("", "User Name Or Password Is Wrong");
            return View(loginViewModel);

        }
                        
            
           

        

        public async Task<IActionResult> Logout() { 
        await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        
        }

        [HttpGet]
        public IActionResult Register() { 
        return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) {

            if (ModelState.IsValid) { 
            
                AppUser appUser = new AppUser();
                appUser.UserName = registerViewModel.UserName;
                appUser.Email = registerViewModel.Email;
                appUser.FirstName = registerViewModel.FirstName;
                appUser.LastName = registerViewModel.LastName;

                IdentityResult result= await _userManager.CreateAsync(appUser , registerViewModel.Password);
                if (result.Succeeded) {
                    List < AppUser > users= _appUserRepository.Read().ToList();
                    if (users.Count == 1)
                    {
                        IdentityRole<int> identityRole = new IdentityRole<int>();
                        identityRole.Name = "Admin";
                        await _roleManager.CreateAsync(identityRole);
                        await _userManager.AddToRoleAsync(appUser, "Admin");

                    }
                    await _userManager.AddClaimAsync(appUser, new Claim("FirstName", appUser.FirstName));

                        await _signInManager.PasswordSignInAsync(registerViewModel.UserName,
                            registerViewModel.Password,
                            false,
                            lockoutOnFailure: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors) {
                    ModelState.AddModelError("", item.Description);  
                }
                
            }
            return View(registerViewModel);

        }


    }
}
