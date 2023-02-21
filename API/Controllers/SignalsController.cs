using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
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
            var spec = new SignalsWithProtocolsSpecification();
            var signals = await _signalsRepo.ListAsync(spec);
            return Ok(signals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Signal>> GetSignal(int id)
        {
            var spec = new SignalsWithProtocolsSpecification(id);
            return await _signalsRepo.GetEntityWithSpec(spec);
        }

        [HttpGet("protocols")]
        public async Task<ActionResult<List<SignalProtocol>>> GetSignalProtocols()
        {
            var signalProtocols = await _signalProtocolsRepo.ListAllAsync();
            return Ok(signalProtocols);
        }
    }
}