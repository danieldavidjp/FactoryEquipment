using Newtonsoft.Json;

namespace FactoryEquipmentDashboard.Services.Extensions
{

    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> DeserializeContentAsync<T>(this HttpResponseMessage response)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResponse);

            return result;
        }
    }

}
