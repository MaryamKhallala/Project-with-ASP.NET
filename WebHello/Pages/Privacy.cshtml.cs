using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHello.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly DataContext db; 
        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext db)
        {
            _logger = logger;
            this.db = db; 
        }

        public void OnGet()
        {

            var livre = new Livre("Livre1", "FA23");
            db.Livres.Add(livre);
            db.SaveChanges();
        }
    }
}
