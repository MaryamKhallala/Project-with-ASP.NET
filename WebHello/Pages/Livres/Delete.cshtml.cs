using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebHello;

namespace WebHello.Pages.Livres
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly WebHello.DataContext _context;

        public DeleteModel(WebHello.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Livre Livre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Livre = await _context.Livres.FirstOrDefaultAsync(m => m.ID == id);

            if (Livre == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Livre = await _context.Livres.FindAsync(id);

            if (Livre != null)
            {
                _context.Livres.Remove(Livre);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
