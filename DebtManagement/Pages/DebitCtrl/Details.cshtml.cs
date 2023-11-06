using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DebtManagement.Models;
using Microsoft.EntityFrameworkCore;

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

        public IList<DebitDetail> DebitDetail { get; set; } = default!;

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

            if (_context.DebitDetails != null)
            {
                DebitDetail = await _context.DebitDetails
                .Include(d => d.Debit)
                .Where(d => d.DebitId == id)
                .ToListAsync();
            }
            decimal TotalAmount = 0;
            foreach (var item in DebitDetail)
            {
                if (item.IsPaid)
                {
                    TotalAmount -= item.Amount;
                }
                else
                {
                    TotalAmount += item.Amount;
                }

            }
            ViewData["TotalAmount"] = TotalAmount.ToString("#,##0");
            return Page();
        }
    }
}
