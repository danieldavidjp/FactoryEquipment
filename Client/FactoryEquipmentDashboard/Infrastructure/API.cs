namespace FactoryEquipmentDashboard.Infrastructure
{
    public static class API
    {
        public static class Equipment
        {
            public static string Create() => "/api/equipments";
            public static string List() => "/api/equipments";

            public static string Get(Guid id) => $"/api/equipments/{id}";

            public static string SetState(Guid id) => $"/api/equipments/{id}";
        }

        public static class StatusLog
        {
            public static string Get() => "/api/statuslogs";

            public static string GetByEquipment(Guid equipmentId) => $"/api/statuslogs/{equipmentId}";

        }
    }
}
