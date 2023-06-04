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

        //protected async Task<TResponse> GetAsync(TResponse url)
        //{
        //    var response = await _client.GetAsync(url);
        //    var content = await response.Content.ReadAsStringAsync();
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new HttpRequestException(content);
        //    }

        //    var result = JsonSerializer.Deserialize<TResponse>(content, _options);
        //    return result;
        //}
    }
}
