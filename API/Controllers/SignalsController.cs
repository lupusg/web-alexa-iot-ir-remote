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
        private readonly ISignalRepository _repo;
        public SignalsController(ISignalRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Signal>>> GetSignal()
        {
            var signals = await _repo.GetSignalsAsync();
            return Ok(signals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Signal>> GetSignal(int id)
        {
            return await _repo.GetSignalByIdAsync(id);
        }
    }
}