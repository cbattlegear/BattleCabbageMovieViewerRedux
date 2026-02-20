namespace BattleCabbageMovieViewer.Models;

public class ActorResponse
{
    private const string ApiBaseUrl = "https://api.battlecabbage.com";

    public int ActorId { get; set; }
    public string Actor { get; set; } = string.Empty;
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
