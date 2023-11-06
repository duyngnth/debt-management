using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Models;

namespace DebtManagement.Pages.DebitCtrl
{
    public class EditModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;

        public EditModel(DebtManagement.Models.DebtManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Debit Debit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Debits == null)
            {
                return NotFound();
            }

            var debit =  await _context.Debits.FirstOrDefaultAsync(m => m.Id == id);
            if (debit == null)
            {
                return NotFound();
            }
            Debit = debit;
            ViewData["CreditorId"] = new SelectList(_context.Users, "Id", "Id");
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

            Debit.CreditorId = HttpContext.Session.GetInt32("userId");
            _context.Attach(Debit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebitExists(Debit.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DebitExists(int id)
        {
          return (_context.Debits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
