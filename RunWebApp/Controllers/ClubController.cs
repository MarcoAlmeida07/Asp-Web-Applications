using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunWebApp.Data;

namespace RunWebApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var clubs = _context.Clubs.ToList();
            return View(clubs);
        }

        [HttpGet("Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var club = _context.Clubs.Include(a=>a.Address).FirstOrDefault(c => c.Id == id);
            return View(club);
        }
    }
}
