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
        private readonly IGenericRepository<SignalProtocol> _signalProtocolsRepo;
        public SignalsController(IGenericRepository<Signal> signalsRepo,
         IGenericRepository<SignalProtocol> signalProtocolsRepo)
        {
            _signalsRepo = signalsRepo;
            _signalProtocolsRepo = signalProtocolsRepo;
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

        [HttpGet("protocols")]
        public async Task<ActionResult<List<SignalProtocol>>> GetSignalProtocols()
        {
            var signalProtocols = await _signalProtocolsRepo.ListAllAsync();
            return Ok(signalProtocols);
        }
    }
}