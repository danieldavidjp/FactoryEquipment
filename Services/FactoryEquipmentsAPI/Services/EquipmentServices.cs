using FactoryEquipmentsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryEquipmentsAPI.Services
{
    public class EquipmentServices : IEquipmentServices
    {
        private readonly FactoryEquipmentContext _context;
        private readonly IStatusLogServices _statusLogServices;

        public EquipmentServices(FactoryEquipmentContext context, IStatusLogServices statusLogServices)
        {
            _context = context;
            _statusLogServices = statusLogServices;
        }
        public async Task<Equipment> CreateEquipment(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }


        public async Task<Equipment> GetEquipment(Guid id)
        { 
            return await _context.Equipment.FindAsync(id);
        }

        public async Task<IEnumerable<Equipment>> ListEquipment()
        {
            return await _context.Equipment.ToListAsync();
        }

        public async Task UpdateEquipment(Guid id, Equipment equipment)
        {
            StatusLog log = new StatusLog()
            {
                Id = Guid.NewGuid(),
                Status = equipment.Status,
                EquipmentId = id,
            };

            await _statusLogServices.PostStatusLog(log);

            _context.Update(equipment);

            await _context.SaveChangesAsync();
        }
    }
}
