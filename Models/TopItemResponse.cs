using System.Text.Json.Serialization;

namespace BattleCabbageMovieViewer.Models;

public class TopActorResponse
{
    public int ActorId { get; set; }
    public string Actor { get; set; } = string.Empty;
    public int MovieCount { get; set; }
}

public class TopDirectorResponse
{
    public int DirectorId { get; set; }
    public string Director { get; set; } = string.Empty;
    public int MovieCount { get; set; }
}

public class TopGenreResponse
{
    public int GenreId { get; set; }
    public string Genre { get; set; } = string.Empty;
    public int MovieCount { get; set; }
}
