using FactoryEquipmentDashboard.Models;

namespace FactoryEquipmentDashboard.Services
{
    public interface IStatusLogService
    {
        Task<IEnumerable<StatusLog>> GetLogs();

        Task<IEnumerable<StatusLog>> GetLogsByEquipments(Guid equipmentId);
    }
}
