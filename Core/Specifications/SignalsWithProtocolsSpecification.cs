using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class SignalsWithProtocolsSpecification : BaseSpecification<Signal>
    {
        public SignalsWithProtocolsSpecification()
        {
            AddInclude(x => x.SignalProtocol);
        }

        public SignalsWithProtocolsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.SignalProtocol);
        }
    }
}