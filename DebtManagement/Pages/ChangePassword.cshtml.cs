using DebtManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DebtManagement.Pages
{
    public class ChangePasswordModel : PageModel
    {
        [BindProperty]
        public string CurrentPassword { get; set; } = "";
        [BindProperty]
        public string NewPassword { get; set; } = "";
        [BindProperty]
        public string RetypeNewPassword { get; set; } = "";
        public string Message { get; set; } = "";

        private readonly DebtManagementContext context;

        public ChangePasswordModel(DebtManagementContext context)
        {
            this.context = context;
        }

        public async Task OnGetAsync()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            User? user = context.Users
                .SingleOrDefault(user => user.Id == HttpContext.Session.GetInt32("userId"));

            string dbCurrentPassword = user.Password;
            if (dbCurrentPassword != CurrentPassword)
            {
                Message = "Wrong current password";
                return Page();
            }

            string passwordRegex = "^(?=.*[A-Za-z])(?=.*\\d).{8,}$";
            if (!Regex.IsMatch(NewPassword, passwordRegex))
            {
                Message = "Password must contains at least 8 characters, including digit and letter";
                return Page();
            }

            if (NewPassword != RetypeNewPassword)
            {
                Message = "New password must match";
                return Page();
            }

            user.Password = NewPassword;
            context.Users.Update(user);
            await context.SaveChangesAsync();

            Message = "Password changed successfully!";
            CurrentPassword = "";
            NewPassword = "";
            RetypeNewPassword = "";
            return Page();
        }
    }
}
