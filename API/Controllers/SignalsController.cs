using API.Dto;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public SignalsController(IGenericRepository<Signal> signalsRepo,
        IGenericRepository<SignalProtocol> signalProtocolsRepo, IMapper mapper)
        {
            this._mapper = mapper;
            _signalsRepo = signalsRepo;
            _signalProtocolsRepo = signalProtocolsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SignalToReturnDto>>> GetSignal()
        {
            var spec = new SignalsWithProtocolsSpecification();
            var signals = await _signalsRepo.ListAsync(spec);
            return Ok(_mapper
                .Map<IReadOnlyList<Signal>, IReadOnlyList<SignalToReturnDto>>(signals));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SignalToReturnDto>> GetSignal(int id)
        {
            var spec = new SignalsWithProtocolsSpecification(id);
            var signal = await _signalsRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Signal, SignalToReturnDto>(signal);
        }

        [HttpGet("protocols")]
        public async Task<ActionResult<List<SignalProtocol>>> GetSignalProtocols()
        {
            var signalProtocols = await _signalProtocolsRepo.ListAllAsync();
            return Ok(signalProtocols);
        }
    }
}