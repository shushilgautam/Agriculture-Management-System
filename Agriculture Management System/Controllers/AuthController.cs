using Agriculture_Management_System.Data;
using Agriculture_Management_System.Models;
using Agriculture_Management_System.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture_Management_System.Controllers
{
    public class AuthController : Controller
    {
        public readonly AppDbContext _context;
        public readonly SignInManager<Users> _signInManager;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =await _signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);

            if (result.Succeeded)
            {
                // redirect to action homepage
            }

            return View(model);
        }

        
    }
}
