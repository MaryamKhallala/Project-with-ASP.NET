using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks; 
using WebHello;
using Microsoft.Extensions.Logging; 
namespace WebHello.Controllers
{
    [ApiController]
    [Route("/api/showLivres")]
    public class LivresControllers : ControllerBase
    {
        private readonly ILogger<LivresControllers> _logger; 
        public IList<Livre> resLivres { get; set; }
        private readonly WebHello.DataContext context; 

        public LivresControllers(ILogger<LivresControllers> logger, WebHello.DataContext co)
        {
            context = co;
            _logger = logger; 
        }

        [HttpGet]
        public async Task<IList<Livre>> Get()
        {
            _logger.LogInformation("[GET]: ");
            resLivres = await context.Livres.ToListAsync();
            return resLivres;
        }


        [HttpGet("{id}")]
        public async Task<Livre> Get(int id)
        {
            _logger.LogInformation("[GET]: "+ id);
            return await context.Livres.FirstOrDefaultAsync(m => m.ID == id); 
        }

        [HttpPost]
        public async Task<string> Post(Livre livre)
        {
            _logger.LogInformation("[POST]: adding Livre");
            
            context.Livres.Add(livre);
            await context.SaveChangesAsync();
            return "Inserted Succefully";
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            Livre livre = await context.Livres.FindAsync(id); 
            if(livre != null)
            {
                context.Livres.Remove(livre);
                await context.SaveChangesAsync();
                return "Deletion succefully";
            }else
            {
                _logger.LogWarning("Searching Livre not exist"); 
                return "Livre n'existe pas"; 
            }
        }
    }
}