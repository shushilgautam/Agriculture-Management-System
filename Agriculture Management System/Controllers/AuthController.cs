using Agriculture_Management_System.Data;
using Agriculture_Management_System.Models;
using Agriculture_Management_System.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Agriculture_Management_System.Controllers
{
    public class AuthController : Controller
    {
        public readonly AppDbContext _context;
        public readonly SignInManager<Users> _signInManager;
        public readonly UserManager<Users> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthController(AppDbContext context, SignInManager<Users> signInManager, UserManager<Users> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =await _signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false);

            if (result.Succeeded)
            {
                // redirect to action homepage
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            string filepath=null;

            if (model.ProfilePhoto != null)
            {
                var uploadFolder = Path.Combine(_webHostEnvironment.ContentRootPath, "uploads/profile_photos");
                var timestamp = DateTime.Now.ToString("yyyyMMddhhmmssfff");
                var random=new Random().Next(0000,9999);
                var uniqueFileName =   $"{timestamp}_{random}"+model.ProfilePhoto.Name+".jpeg";
                filepath = Path.Combine(uploadFolder, uniqueFileName);
                using(var filestream = new  FileStream(filepath, FileMode.Create))
                {
                    await model.ProfilePhoto.CopyToAsync(filestream);
                }
            }

            Console.WriteLine($"Filepath : {filepath}");
            var user = new Users
            {
                Email = model.Email,
                UserName = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                ProfilePicturePath =filepath
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
                return RedirectToAction("Login", "Auth");
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        
    }
}
