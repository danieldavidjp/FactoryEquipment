using FactoryEquipmentsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryEquipmentsAPI.Services
{
    public class StatusLogServices : IStatusLogServices
    {
        private readonly FactoryEquipmentContext _context;

        public StatusLogServices(FactoryEquipmentContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StatusLog>> GetStatusLogs()
        {
            return await _context.StatusLogs.ToListAsync();
        }

        public async Task<IEnumerable<StatusLog>> GetStatusLogsByEquipment(Guid equipmentId)
        {
            return await _context.StatusLogs.Where(e => e.EquipmentId == equipmentId).ToListAsync();
        }

        public async Task PostStatusLog(StatusLog statusLog)
        {
            _context.StatusLogs.Add(statusLog);
            await _context.SaveChangesAsync();
        }
    }
}
