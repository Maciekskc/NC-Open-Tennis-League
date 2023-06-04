using System.Text;
using System.Text.Json;

namespace Application.Repositories
{
    public abstract class BaseHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public BaseHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var response = await _client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(content);
            }

            var result = JsonSerializer.Deserialize<TResponse>(content, _options);
            return result;
        }

        protected async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest requestData)
        {
            var jsonContent = JsonSerializer.Serialize(requestData, _options);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(responseContent);
            }

            var result = JsonSerializer.Deserialize<TResponse>(responseContent, _options);
            return result;
        }

        protected async Task PostAsync<TRequest>(string url, TRequest requestData)
        {
            var jsonContent = JsonSerializer.Serialize(requestData, _options);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(responseContent);
            }
        }

        protected async Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest requestData)
        {
            var jsonContent = JsonSerializer.Serialize(requestData, _options);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(responseContent);
            }

            var result = JsonSerializer.Deserialize<TResponse>(responseContent, _options);
            return result;
        }

        protected async Task PutAsync<TRequest>(string url, TRequest requestData)
        {
            var jsonContent = JsonSerializer.Serialize(requestData, _options);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(responseContent);
            }
        }

        protected async Task DeleteAsync(string url)
        {
            var response = await _client.DeleteAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(responseContent);
            }
        }
    }
}
