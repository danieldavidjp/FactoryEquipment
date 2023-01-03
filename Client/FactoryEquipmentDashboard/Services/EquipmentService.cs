using FactoryEquipmentDashboard.Infrastructure;
using FactoryEquipmentDashboard.Models;
using FactoryEquipmentDashboard.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;

namespace FactoryEquipmentDashboard.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly HttpClient _httpClient;

        public EquipmentService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task ChangeEquipmentState(Guid equipmentId, Equipment equipment)
        {
            var uri = API.Equipment.SetState(equipmentId);

            var body = new
            {
                Id = equipment.Id,
                Status = equipment.Status.ToString(),
                Name = equipment.Name,
                CreatedAt = equipment.CreatedAt,
            };

            var content = new StringContent(JsonConvert.SerializeObject(body),
                Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await _httpClient.PutAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Equipment> CreateEquipment(string name)
        {
            var uri = API.Equipment.Create();

            var body = new
            { 
                Name = name,
                Status = nameof(EquipmentStates.Red),
            };

            var content = new StringContent(JsonConvert.SerializeObject(body),
                Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();

            return await response.DeserializeContentAsync<Equipment>();
        }

        public async Task<Equipment> GetEquipment(Guid id)
        {
            var uri = API.Equipment.Get(id);

            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            return await response.DeserializeContentAsync<Equipment>();
        }

        public async Task<IEnumerable<Equipment>> ListEquipments()
        {
            var uri = API.Equipment.List();

            var response = await _httpClient.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            return await response.DeserializeContentAsync<IEnumerable<Equipment>>();
        }
    }
}
