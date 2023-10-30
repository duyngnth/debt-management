using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DebtManagement.Models;

namespace DebtManagement.Pages.DebitDetailCtrl
{
    public class DetailsModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;

        public DetailsModel(DebtManagement.Models.DebtManagementContext context)
        {
            _context = context;
        }

      public DebitDetail DebitDetail { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DebitDetails == null)
            {
                return NotFound();
            }

            var debitdetail = await _context.DebitDetails.FirstOrDefaultAsync(m => m.Id == id);
            if (debitdetail == null)
            {
                return NotFound();
            }
            else 
            {
                DebitDetail = debitdetail;
            }
            return Page();
        }
    }
}
