using API.Dto;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

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
        
        [Cached(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<SignalToReturnDto>>> GetSignals(
            [FromQuery] SignalsSpecParams signalParams)
        {
            var spec = new SignalsWithProtocolsSpecification(signalParams);

            var countSpec = new SignalsWithFiltersForCountSpecification(signalParams);

            var totalItems = await _signalsRepo.CountAsync(countSpec);

            var signals = await _signalsRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Signal>, IReadOnlyList<SignalToReturnDto>>(signals);

            return Ok(new Pagination<SignalToReturnDto>(signalParams.PageIndex,
                signalParams.PageSize, totalItems, data));
        }

        [Cached(600)]
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

        [Cached(600)]
        [HttpGet("protocols")]
        public async Task<ActionResult<List<SignalProtocol>>> GetSignalProtocols()
        {
            var signalProtocols = await _signalProtocolsRepo.ListAllAsync();

            return Ok(signalProtocols);
        }
    }
}