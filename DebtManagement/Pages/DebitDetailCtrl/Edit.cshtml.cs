using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Models;

namespace DebtManagement.Pages.DebitDetailCtrl
{
    public class EditModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;

        public EditModel(DebtManagement.Models.DebtManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DebitDetail DebitDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DebitDetails == null)
            {
                return NotFound();
            }

            var debitdetail =  await _context.DebitDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (debitdetail == null)
            {
                return NotFound();
            }
            DebitDetail = debitdetail;
           ViewData["DebitId"] = new SelectList(_context.Debits, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DebitDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebitDetailExists(DebitDetail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var routeValues = new { id = DebitDetail.DebitId };
            return RedirectToPage("./Index", routeValues);
        }

        private bool DebitDetailExists(int id)
        {
          return (_context.DebitDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
