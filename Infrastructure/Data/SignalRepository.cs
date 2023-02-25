using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SignalRepository : ISignalRepository
    {
        private readonly ManagerContext _context;
        public SignalRepository(ManagerContext context)
        {
            _context = context;
        }

        public async Task<Signal> GetSignalByIdAsync(int id)
        {
            return await _context.Signals
                .Include(s => s.SignalProtocol)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IReadOnlyList<Signal>> GetSignalsAsync()
        {
            var singnals = _context.Signals.Include(x => x.SignalProtocol).ToListAsync();

            return await _context.Signals
                .Include(s => s.SignalProtocol)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<SignalProtocol>> GetSignalProtocolsAsync()
        {
            return await _context.SignalProtocols.ToListAsync();
        }
    }
}