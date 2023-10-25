using DebtManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DebtManagement.Pages.Shared
{
    public class LoginModel : PageModel
    {
        private readonly DebtManagementContext _context;
        [BindProperty]
        public string Email { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        public LoginModel(DebtManagementContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("userName");
        }
        public IActionResult OnPost(string Email, string Password)
        {
            if (!ModelState.IsValid || _context.Users == null)
            {
                return Page();
            }
            //check if email already exist
            User? user = _context.Users.Where(
                u => u.Email.ToLower().Equals(Email.ToLower())
                )?.FirstOrDefault();
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email is incorrect or not exist!");
                return Page();
            }
            else if(!user.Password.Equals(Password))
            {
                ModelState.AddModelError("Password", "Password is incorrect!");
                return Page();
            }
            HttpContext.Session.SetInt32("userId", user.Id);
            HttpContext.Session.SetString("userName", user.DisplayName);
            return RedirectToPage("/Index");
        }
    }
}
