using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunWebApp.Data;

namespace RunWebApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RaceController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var races = _context.Races.ToList();
            return View(races);
        }

        [HttpGet("Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var race = _context.Races.Include(a => a.Address).FirstOrDefault(r => r.Id == id);
            return View(race);
        }
    }
}
