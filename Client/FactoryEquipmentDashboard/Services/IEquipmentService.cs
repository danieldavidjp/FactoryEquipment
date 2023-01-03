using FactoryEquipmentDashboard.Models;

namespace FactoryEquipmentDashboard.Services
{
    public interface IEquipmentService
    {
        Task<Equipment> CreateEquipment(string Name);

        Task<IEnumerable<Equipment>> ListEquipments();

        Task ChangeEquipmentState(Guid equipmentId, Equipment equipment);

        Task<Equipment> GetEquipment(Guid id);
    }
}
