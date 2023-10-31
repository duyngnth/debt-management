using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DebtManagement.Models;

namespace DebtManagement.Pages.DebitCtrl
{
    public class CreateModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;

        public CreateModel(DebtManagement.Models.DebtManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CreditorId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Debit Debit { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Debits == null || Debit == null)
            {
                return Page();
            }

            Debit.CreditorId = HttpContext.Session.GetInt32("userId");
            _context.Debits.Add(Debit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
