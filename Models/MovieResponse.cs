namespace BattleCabbageMovieViewer.Models;

public class MovieResponse
{
    private const string ApiBaseUrl = "https://api.battlecabbage.com";
    private const string PlaceholderImage = "https://placehold.co/400x600/667eea/white?text=Coming+Soon";
    
    public int? MovieId { get; set; }
    public string ExternalId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Tagline { get; set; }
    public string? MpaaRating { get; set; }
    public string? Description { get; set; }
    public decimal? PopularityScore { get; set; }
    public string? Genre { get; set; }
    public string? PosterUrl { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public List<ActorResponse> Actors { get; set; } = [];
    public List<DirectorResponse> Directors { get; set; } = [];
    public List<ReviewResponse> Reviews { get; set; } = [];

    public decimal? AverageScore => Reviews.Count > 0 
        ? Reviews.Where(r => r.CriticScore.HasValue).Average(r => r.CriticScore!.Value) 
        : null;

    public string? FullPosterUrl
    {
        get
        {
            if (string.IsNullOrEmpty(PosterUrl))
                return null;
            
            // If it's the placeholder filename, return a filler image
            if (PosterUrl == "movie_poster_url.jpeg" || PosterUrl.EndsWith("/movie_poster_url.jpeg"))
                return PlaceholderImage;
            
            // If it's already a full URL, return as-is
            if (PosterUrl.StartsWith("http://") || PosterUrl.StartsWith("https://"))
                return PosterUrl;
            
            // Otherwise, prepend the API base URL
            return $"{ApiBaseUrl}/{PosterUrl.TrimStart('/')}";
        }
    }
}
