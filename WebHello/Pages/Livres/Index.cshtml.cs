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
    public class IndexModel : PageModel
    {
        private readonly WebHello.DataContext _context;

        public IndexModel(WebHello.DataContext context)
        {
            _context = context;
        }

        public IList<Livre> Livre { get;set; }

        public async Task OnGetAsync()
        {
            Livre = await _context.Livres.ToListAsync();
        }
    }
}
