using System;
using System.Text.Json;
using TravelFrontend.Models;

namespace TravelFrontend.Services;

public class TravelApiService : ITravelApiService
{
    private readonly HttpClient _client;
    public TravelApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Destination>> GetAllAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "api/Destinations") { };

        var response = await _client.SendAsync(request);

        var destination = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<List<Destination>>(destination, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
