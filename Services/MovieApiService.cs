using BattleCabbageMovieViewer.Models;
using System.Text.Json;

namespace BattleCabbageMovieViewer.Services;

public interface IMovieApiService
{
    // Movies
    Task<List<MovieResponse>> GetMoviesAsync(int skip = 0, int limit = 10, string? genre = null);
    Task<MovieResponse?> GetMovieAsync(int movieId);
    Task<List<MovieResponse>> GetRandomMoviesAsync();
    Task<List<MovieResponse>> GetTopRatedMoviesAsync();
    Task<List<MovieResponse>> GetWorstRatedMoviesAsync();
    Task<List<MovieResponse>> GetRecentMoviesAsync();

    // Actors
    Task<List<ActorResponse>> GetActorsAsync(int skip = 0, int limit = 50);
    Task<ActorResponse?> GetActorAsync(int actorId);
    Task<List<TopActorResponse>> GetTopActorsAsync();
    Task<List<MovieResponse>> GetActorMoviesAsync(int actorId);

    // Directors
    Task<List<DirectorResponse>> GetDirectorsAsync(int skip = 0, int limit = 50);
    Task<List<TopDirectorResponse>> GetTopDirectorsAsync();

    // Genres
    Task<List<GenreResponse>> GetGenresAsync();
    Task<List<TopGenreResponse>> GetTopGenresAsync();

    // Stats
    Task<StatsResponse?> GetStatsAsync();
}

public class MovieApiService : IMovieApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonOptions;

    public MovieApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
    }

    // Movies
    public async Task<List<MovieResponse>> GetMoviesAsync(int skip = 0, int limit = 10, string? genre = null)
    {
        var url = $"movies?skip={skip}&limit={limit}";
        if (!string.IsNullOrEmpty(genre))
        {
            url += $"&genre={Uri.EscapeDataString(genre)}";
        }
        return await GetAsync<List<MovieResponse>>(url) ?? [];
    }

    public async Task<MovieResponse?> GetMovieAsync(int movieId)
    {
        return await GetAsync<MovieResponse>($"movies/{movieId}");
    }

    public async Task<List<MovieResponse>> GetRandomMoviesAsync()
    {
        return await GetAsync<List<MovieResponse>>("movies/random") ?? [];
    }

    public async Task<List<MovieResponse>> GetTopRatedMoviesAsync()
    {
        return await GetAsync<List<MovieResponse>>("movies/top-rated") ?? [];
    }

    public async Task<List<MovieResponse>> GetWorstRatedMoviesAsync()
    {
        return await GetAsync<List<MovieResponse>>("movies/worst-rated") ?? [];
    }

    public async Task<List<MovieResponse>> GetRecentMoviesAsync()
    {
        return await GetAsync<List<MovieResponse>>("movies/recent") ?? [];
    }

    // Actors
    public async Task<List<ActorResponse>> GetActorsAsync(int skip = 0, int limit = 50)
    {
        return await GetAsync<List<ActorResponse>>($"actors?skip={skip}&limit={limit}") ?? [];
    }

    public async Task<ActorResponse?> GetActorAsync(int actorId)
    {
        return await GetAsync<ActorResponse>($"actors/{actorId}");
    }

    public async Task<List<TopActorResponse>> GetTopActorsAsync()
    {
        return await GetAsync<List<TopActorResponse>>("actors/top") ?? [];
    }

    public async Task<List<MovieResponse>> GetActorMoviesAsync(int actorId)
    {
        return await GetAsync<List<MovieResponse>>($"actors/{actorId}/movies") ?? [];
    }

    // Directors
    public async Task<List<DirectorResponse>> GetDirectorsAsync(int skip = 0, int limit = 50)
    {
        return await GetAsync<List<DirectorResponse>>($"directors?skip={skip}&limit={limit}") ?? [];
    }

    public async Task<List<TopDirectorResponse>> GetTopDirectorsAsync()
    {
        return await GetAsync<List<TopDirectorResponse>>("directors/top") ?? [];
    }

    // Genres
    public async Task<List<GenreResponse>> GetGenresAsync()
    {
        return await GetAsync<List<GenreResponse>>("genres") ?? [];
    }

    public async Task<List<TopGenreResponse>> GetTopGenresAsync()
    {
        return await GetAsync<List<TopGenreResponse>>("genres/top") ?? [];
    }

    // Stats
    public async Task<StatsResponse?> GetStatsAsync()
    {
        return await GetAsync<StatsResponse>("stats");
    }

    private async Task<T?> GetAsync<T>(string endpoint)
    {
        try
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content, _jsonOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching {endpoint}: {ex.Message}");
            return default;
        }
    }
}
