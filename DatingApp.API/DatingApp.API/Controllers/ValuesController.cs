using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetValues()
        {
            return Ok(await _context.Values.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetValue(int id)
        {
            Value value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            if (value == null)
                return NotFound();

            return Ok(value);
        }
    }
}