using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class SignalsWithFiltersForCountSpecification : BaseSpecification<Signal>
    {
        private readonly SignalsSpecParams _signalParams;
        public SignalsWithFiltersForCountSpecification(SignalsSpecParams signalParams) : 
            base(x =>
                (string.IsNullOrEmpty(signalParams.Search) || x.Name.ToLower().Contains(signalParams.Search)) &&
                (!signalParams.ProtocolId.HasValue || x.SignalProtocolId == signalParams.ProtocolId)
            )
        {
            _signalParams = signalParams;
        }
    }
}