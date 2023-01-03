using FactoryEquipmentsAPI.Models;

namespace FactoryEquipmentsAPI.Services
{
    public interface IEquipmentServices
    {
        Task<IEnumerable<Equipment>> ListEquipment();
        Task<Equipment> GetEquipment(Guid id);

        Task UpdateEquipment(Guid id,Equipment equipment);

        Task<Equipment> CreateEquipment(Equipment equipment);
    }
}
