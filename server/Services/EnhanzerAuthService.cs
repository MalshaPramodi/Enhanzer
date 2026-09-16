using Server.DTOs;
using System.Text;
using System.Text.Json;

namespace Server.Services
{
    public class EnhanzerAuthService : IEnhanzerAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<EnhanzerAuthService> _logger;
        private const string InvokeUrl = "https://ez-staging-api.azurewebsites.net/api/External_Api/POS_Api/Invoke";

        public EnhanzerAuthService(HttpClient httpClient, ILogger<EnhanzerAuthService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<EnhanzerInvokeResponse?> LoginAsync(string email, string password)
        {
            var requestBody = new EnhanzerInvokeRequest
            {
                Company_Code = email,
                API_Body = new EnhanzerLoginBody
                {
                    Username = email,
                    Pw = password
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.PostAsync(InvokeUrl, content);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to reach Enhanzer invoke API");
                return null;
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            // Temporary — lets us see the REAL shape of the response the first time we call this.
            _logger.LogInformation("Enhanzer API raw response: {Response}", responseBody);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Enhanzer API returned status {Status}", response.StatusCode);
                return null;
            }

            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<EnhanzerInvokeResponse>(responseBody, options);
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Failed to parse Enhanzer API response: {Raw}", responseBody);
                return null;
            }
        }
    }
}