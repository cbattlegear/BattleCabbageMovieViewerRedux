namespace BattleCabbageMovieViewer.Models;

public class DirectorResponse
{
    private const string ApiBaseUrl = "https://api.battlecabbage.com";

    public int DirectorId { get; set; }
    public string Director { get; set; } = string.Empty;
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
