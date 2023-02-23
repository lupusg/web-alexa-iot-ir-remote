using API.Dto;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class SignalsController : BaseApiController
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SignalToReturnDto>> GetSignal(int id)
        {
            var spec = new SignalsWithProtocolsSpecification(id);

            var signal = await _signalsRepo.GetEntityWithSpec(spec);

            if (signal == null)
            {
                return NotFound(new ApiResponse(404));
            }

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