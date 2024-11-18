using System.Text.Json;
using Core.Interface;
using StackExchange.Redis;

namespace Infrastructure.Services;

public class ResponseCacheService(IConnectionMultiplexer redis) : IResponseCacheService
{
    private readonly IDatabase _database = redis.GetDatabase(1);
    public async Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeToLive)
    {
        var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

        var serializeResponse = JsonSerializer.Serialize(response, options);

        await _database.StringSetAsync(cacheKey, serializeResponse, timeToLive);
    }

    public async Task<string?> GetCachedResponseAsync(string cacheKey)
    {
        var cacheResponseAsync = await _database.StringGetAsync(cacheKey);

        if(cacheResponseAsync.IsNullOrEmpty) return null;

        return cacheResponseAsync;
    }

    public async Task RemoveCacheByPattern(string pattern)
    {
        var server = redis.GetServer(redis.GetEndPoints().First());
        var keys = server.Keys(database: 1, pattern: $"*{pattern}*").ToArray();

        if(keys.Length != 0)
        {
            await _database.KeyDeleteAsync(keys);
        }
    }
}
