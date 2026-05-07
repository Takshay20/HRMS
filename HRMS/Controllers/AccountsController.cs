//using HRMS.Data;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace HRMS.Controllers
//{
//    public class AccountsController : Controller
//    {
//        private readonly AppDbContext _context;
//        public AccountsController(AppDbContext context)
//        {

//            _context = context;
//        }
//        public ActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Login(string username, string password)
//        {
//            var user = await _context.UserAccounts
//                .Include(u => u.RoleId)
//                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password && u.IsActive);
//            if (user != null)
//            {
//                HttpContext.Session.SetString("Username", user.UserName);
//                HttpContext.Session.SetString("Role", user.Role!.RoleName);
//                HttpContext.Session.SetInt32("UserId", user.UserAccountId);
//                return RedirectToAction("Dashboard", "Home");
//            }

//            ViewBag.ErrorMessage = "Invalid username or password";
//            ModelState.AddModelError("", "Invalid username or password");
//            return View();
//        }

//        public IActionResult Logout()
//        {
//            HttpContext.Session.Clear();
//            return RedirectToAction("Login");


//        }
//    }

//}
