namespace FactoryEquipmentDashboard.Models
{
    public sealed record StatusLog(Guid Id, EquipmentStates Status, Guid EquipmentId, DateTime CreatedAt);
}
