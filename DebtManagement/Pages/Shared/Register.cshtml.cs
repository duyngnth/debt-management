using DebtManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DebtManagement.Pages.Shared
{
    public class RegisterModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;
        [BindProperty]
        public string Email { get; set; } = string.Empty;
        [StringLength(24, ErrorMessage = "{0} must be between {2} and {1} characters.", MinimumLength = 8)]
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        [BindProperty]
        public string ConfirmPassword { get; set; } = string.Empty;
        [StringLength(24, ErrorMessage = "{0} must be between {2} and {1} characters.", MinimumLength = 8)]
        [BindProperty]
        public string DisplayName { get; set; } = string.Empty;
        public RegisterModel(DebtManagementContext context )
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string Email, string Password, string ConfirmPassword, string DisplayName)
        {
            if (!ModelState.IsValid || _context.Users == null)
            {
                return Page();
            }
            else if(ModelState.IsValid)
            {
                bool validation = true;
                Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                Match match = regex.Match(Email);
                
                //check email regex
                if (!match.Success)
                {
                    ModelState.AddModelError("Email", "Email must follow the correct format (Example: a@gmail.com)");
                    validation = false;
                }else
                {
                    //check if email already exist
                    string? existEmail = _context.Users.Where(
                        u => u.Email.ToLower().Equals(Email.ToLower())
                        )?.FirstOrDefault()?.Email;
                    if(existEmail != null)
                    {
                        ModelState.AddModelError("Email", "Email already exist");
                        validation = false;
                    }
                }

                //check if user name already exist
                string? existedUserName = _context.Users.Where(
                    u => u.DisplayName.ToLower().Equals(DisplayName.ToLower())
                    )?.FirstOrDefault()?.DisplayName;
                if (existedUserName != null)
                {
                    ModelState.AddModelError("DisplayName", "User Name already exist");
                    validation = false;
                }

                //check password and confirm password
                if (!Password.Equals(ConfirmPassword))
                {
                    ModelState.AddModelError("ConfirmPassword", "Not match password!");
                    validation = false;
                }

                if (!validation)
                {
                    return Page();
                }

            }
            _context.Users.Add(new User()
            {
                Email = Email,
                Password = Password,
                DisplayName = DisplayName,
            });
            await _context.SaveChangesAsync();
            return RedirectToPage("./Login");
        }
    }
}
