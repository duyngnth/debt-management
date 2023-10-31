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
    public class IndexModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;

        public IndexModel(DebtManagement.Models.DebtManagementContext context)
        {
            _context = context;
        }

        public Debit Debit { get; set; }

        public IList<DebitDetail> DebitDetail { get; set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            if (_context.DebitDetails != null)
            {
                DebitDetail = await _context.DebitDetails
                .Include(d => d.Debit)
                .Where(d => d.DebitId == id)
                .ToListAsync();
            }

            Debit = await _context.Debits
                .Where(d => d.Id.Equals(id))
                .FirstAsync();
        }
    }
}
