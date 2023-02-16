using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignalsController : ControllerBase
    {
        private readonly ManagerContext _context;
        public SignalsController(ManagerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Signal>>> GetSignal()
        {
            var products = await _context.Signals.ToListAsync();
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Signal>> GetSignal(int id)
        {
            return await _context.Signals.FindAsync(id);
        }
    }
}