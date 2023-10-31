using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DebtManagement.Models;

namespace DebtManagement.Pages.DebitDetailCtrl
{
    public class CreateModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;

        public int DebitId { get; set; }

        public CreateModel(DebtManagement.Models.DebtManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            DebitId = id.Value;
            return Page();
        }

        [BindProperty]
        public DebitDetail DebitDetail { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.DebitDetails == null || DebitDetail == null)
            {
                return Page();
            }

            _context.DebitDetails.Add(DebitDetail);
            await _context.SaveChangesAsync();

            var routeValues = new { id = DebitDetail.DebitId };
            return RedirectToPage("./Index", routeValues);
        }
    }
}
