using FactoryEquipmentsAPI.Models;

namespace FactoryEquipmentsAPI.Services
{
    public interface IStatusLogServices
    {
        Task<IEnumerable<StatusLog>> GetStatusLogs();

        Task<IEnumerable<StatusLog>> GetStatusLogsByEquipment(Guid equipmentId);

        Task PostStatusLog(StatusLog statusLog);
    }
}
