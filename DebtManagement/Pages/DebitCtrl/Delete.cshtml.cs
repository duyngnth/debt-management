﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Models;

namespace DebtManagement.Pages.DebitCtrl
{
    public class DeleteModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;

        public DeleteModel(DebtManagement.Models.DebtManagementContext context)
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

            var debit = await _context.Debits.FirstOrDefaultAsync(m => m.Id == id);

            if (debit == null)
            {
                return NotFound();
            }
            else 
            {
                Debit = debit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Debits == null)
            {
                return NotFound();
            }
            var debit = await _context.Debits.FindAsync(id);

            if (debit != null)
            {
                Debit = debit;
                _context.Debits.Remove(Debit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
