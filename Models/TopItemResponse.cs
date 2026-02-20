using System.Text.Json.Serialization;

namespace BattleCabbageMovieViewer.Models;

public class TopActorResponse
{
    private const string ApiBaseUrl = "https://api.battlecabbage.com";

    public int ActorId { get; set; }
    public string Actor { get; set; } = string.Empty;
    public int MovieCount { get; set; }
    public string? ImageUrl { get; set; }

    public string? FullImageUrl
    {
        get
        {
            if (string.IsNullOrEmpty(ImageUrl))
                return null;
            if (ImageUrl.StartsWith("http://") || ImageUrl.StartsWith("https://"))
                return ImageUrl;
            return $"{ApiBaseUrl}/{ImageUrl.TrimStart('/')}";
        }
    }
}

public class TopDirectorResponse
{
    private const string ApiBaseUrl = "https://api.battlecabbage.com";

    public int DirectorId { get; set; }
    public string Director { get; set; } = string.Empty;
    public int MovieCount { get; set; }
    public string? ImageUrl { get; set; }

    public string? FullImageUrl
    {
        get
        {
            if (string.IsNullOrEmpty(ImageUrl))
                return null;
            if (ImageUrl.StartsWith("http://") || ImageUrl.StartsWith("https://"))
                return ImageUrl;
            return $"{ApiBaseUrl}/{ImageUrl.TrimStart('/')}";
        }
    }
}

public class TopGenreResponse
{
    public int GenreId { get; set; }
    public string Genre { get; set; } = string.Empty;
    public int MovieCount { get; set; }
}
