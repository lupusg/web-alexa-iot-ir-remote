using Core.Entities;

namespace Core.Specifications
{
    public class SignalsWithProtocolsSpecification : BaseSpecification<Signal>
    {
        public SignalsWithProtocolsSpecification(SignalsSpecParams signalParams) : 
            base(x =>
                (string.IsNullOrEmpty(signalParams.Search) || x.Name.ToLower().Contains(signalParams.Search)) &&
                (!signalParams.ProtocolId.HasValue || x.SignalProtocolId == signalParams.ProtocolId)
            )
        {
            AddInclude(x => x.SignalProtocol);
            ApplyPaging(signalParams.PageSize * (signalParams.PageIndex - 1), signalParams.PageSize);

            if (!string.IsNullOrEmpty(signalParams.Sort))
            {
                switch (signalParams.Sort)
                {
                    case "idAsc":
                        AddOrderBy(x => x.Id);
                        break;
                    case "idDesc":
                        AddOrderByDescending(x => x.Id);
                        break;
                    case "nameAsc":
                        AddOrderBy(x => x.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(x => x.Name);
                        break;
                    case "protocolAsc":
                        AddOrderBy(x => x.SignalProtocol.Name);
                        break;
                    case "protocolDesc":
                        AddOrderByDescending(x => x.SignalProtocol.Name);
                        break;
                    case "dateAsc":
                        AddOrderBy(x => x.CreatedAt);
                        break;
                    case "dateDesc":
                        AddOrderByDescending(x => x.CreatedAt);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public SignalsWithProtocolsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.SignalProtocol);
        }
    }
}