using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DebtManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DebtManagement.Pages.Shared
{
    public class ProfileModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;

        public ProfileModel(DebtManagement.Models.DebtManagementContext context)
        {
            _context = context;
        }
        public User User { get; set; } = new User();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                User = user;
            }
            return Page();
        }
    }
}
