namespace FactoryEquipmentDashboard.Models
{
    public sealed record Equipment(string Id, string Name, EquipmentStates Status, DateTime CreatedAt);
}
