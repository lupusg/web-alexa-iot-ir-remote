using Core.Entities;

namespace Core.Interfaces
{
    public interface ISignalRepository
    {
        Task<Signal> GetSignalByIdAsync(int id);
        Task<IReadOnlyList<Signal>> GetSignalsAsync();
        Task<IReadOnlyList<SignalProtocol>> GetSignalProtocolsAsync();
    }
}