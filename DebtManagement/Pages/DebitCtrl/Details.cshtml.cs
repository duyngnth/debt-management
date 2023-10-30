using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Models;

namespace DebtManagement.Pages.DebitCtrl
{
    public class DetailsModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;

        public DetailsModel(DebtManagement.Models.DebtManagementContext context)
        {
            _context = context;
        }

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
    }
}
