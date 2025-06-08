using MVC_PrintPayment.Models;
using System.Text.Json;

namespace MVC_PrintPayment.Services
{
    public class PrintPaymentServices : IPrintPaymentServices
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public PrintPaymentServices(HttpClient client, IConfiguration config)
        {
            _client = client;
            _baseUrl = config["WebAPI:BaseUrl"];
        }

        public async Task<string> AddQuotaByUidAsync(AddQuotaByUidM model)
        {
            var response = await _client.PostAsJsonAsync($"{_baseUrl}/print/uid/{model.UID}", model.Amount);
            if (!response.IsSuccessStatusCode)
                return "Failed to add quota.";

            return "Quota successfully added.";
        }

        public async Task<List<StudentQuotaM>> GetAllStudentsAsync()
        {
            var response = await _client.GetAsync(_baseUrl + "/students/all");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var students = JsonSerializer.Deserialize<List<StudentQuotaM>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return students ?? new List<StudentQuotaM>();
        }

        public async Task AddQuotaToStudentsAsync(FacultyQuotaM model)
        {
            foreach (var username in model.SelectedUsernames)
            {
                await _client.PostAsJsonAsync($"{_baseUrl}/print/username/{username}", model.Amount);
            }
        }

        public async Task<StudentQuotaM?> GetBalanceAsync(BalanceQueryM model)
        {
            var identifier = string.IsNullOrWhiteSpace(model.UID) ? model.Username : model.UID;
            var response = await _client.GetAsync($"{_baseUrl}/students/{identifier}");

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<StudentQuotaM>();
        }
    }
}
