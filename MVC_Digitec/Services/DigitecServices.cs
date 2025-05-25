using MVC_Digitec.Models;
using System.Text.Json;

namespace MVC_Digitec.Services
{
    public class DigitecServices : IDigitecServices
    {

        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public DigitecServices(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _baseUrl = configuration["WebAPI:BaseUrl"];
        }


        public async Task<List<ItemM>> GetItems()
        {
            var response = await _client.GetAsync(_baseUrl + "/Digitec");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var items = JsonSerializer.Deserialize<List<ItemM>>(responseBody, options);
            return items;


        }

        public async Task<ItemM> GetItem(int id)
        {
            var response = await _client.GetAsync(_baseUrl + "/Digitec/GetItem/" + id);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var item = JsonSerializer.Deserialize<ItemM>(responseBody, options);
            return item;


        }

        public async Task<ItemM> PutItem(ItemM item)
        {
            var response = await _client.PutAsJsonAsync(_baseUrl + "/Digitec", item);
            response.EnsureSuccessStatusCode();
            var itemReturned = await response.Content.ReadFromJsonAsync<ItemM>();
            return itemReturned;
        }

        public async Task<ItemM> PostItem(ItemM item)
        {
            // step 2
            var response = await _client.PostAsJsonAsync(_baseUrl + "/Digitec", item);
            response.EnsureSuccessStatusCode();
            var itemReturned = await response.Content.ReadFromJsonAsync<ItemM>();
            return itemReturned;

        }

        public async Task<List<EmployeeM>> GetEmployees()
        {
            var response = await _client.GetAsync(_baseUrl + "/Employees");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var employees = JsonSerializer.Deserialize<List<EmployeeM>>(responseBody, options);
            return employees;


        }

    }
}
