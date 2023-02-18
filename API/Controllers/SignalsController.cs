using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignalsController : ControllerBase
    {
        private readonly IGenericRepository<Signal> _signalsRepo;
        public SignalsController(IGenericRepository<Signal> signalsRepo)
        {
            _signalsRepo = signalsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Signal>>> GetSignal()
        {
            var signals = await _signalsRepo.ListAllAsync();
            return Ok(signals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Signal>> GetSignal(int id)
        {
            return await _signalsRepo.GetByIdAsync(id);
        }
    }
}