namespace BattleCabbageMovieViewer.Models;

public class GenreResponse
{
    public int GenreId { get; set; }
    public string Genre { get; set; } = string.Empty;
    public int? MovieCount { get; set; }
}
