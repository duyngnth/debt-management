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
    public class IndexModel : PageModel
    {
        private readonly DebtManagement.Models.DebtManagementContext _context;

        public IndexModel(DebtManagement.Models.DebtManagementContext context)
        {
            _context = context;
        }

        public IList<Debit> Debits { get;set; } = default!;

        public async Task OnGetAsync()
        {

            if (_context.Debits != null)
            {
                Debits = await _context.Debits
                .Include(d => d.Creditor)
                .Include(d => d.DebitDetails)
                .Where(x => x.CreditorId == HttpContext.Session.GetInt32("userId"))
                .ToListAsync();

                foreach (var debit in Debits)
                {
                    debit.RemainingAmount = 0;
                    foreach (var detail in debit.DebitDetails)
                    {
                        if (!detail.IsPaid)
                            debit.RemainingAmount += detail.Amount;
                        else
                            debit.RemainingAmount -= detail.Amount;
                    }
                }
            }
        }
    }
}
