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
            return await _context.Signals.FindAsync(id);
        }

        public async Task<IReadOnlyList<Signal>> GetSignalsAsync()
        {
            return await _context.Signals.ToListAsync();
        }
    }
}