using FactoryEquipmentDashboard.Infrastructure;
using FactoryEquipmentDashboard.Models;
using FactoryEquipmentDashboard.Services.Extensions;

namespace FactoryEquipmentDashboard.Services
{
    public class StatusLogService : IStatusLogService
    {
        private readonly HttpClient _httpClient;

        public StatusLogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<StatusLog>> GetLogs()
        {
            var Uri = API.StatusLog.Get();

            var response = await _httpClient.GetAsync(Uri);
            response.EnsureSuccessStatusCode();

            return await response.DeserializeContentAsync<IEnumerable<StatusLog>>();
        }

        public async Task<IEnumerable<StatusLog>> GetLogsByEquipments(Guid equipmentId)
        {
            var Uri = API.StatusLog.GetByEquipment(equipmentId);

            var response = await _httpClient.GetAsync(Uri);
            response.EnsureSuccessStatusCode();

            return await response.DeserializeContentAsync<IEnumerable<StatusLog>>();
        }
    }
}
