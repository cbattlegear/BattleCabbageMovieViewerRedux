namespace BattleCabbageMovieViewer.Models;

public class StatsResponse
{
    public int TotalMovies { get; set; }
    public int TotalReviews { get; set; }
    public int TotalActors { get; set; }
    public int TotalDirectors { get; set; }
    public Dictionary<string, int> Genres { get; set; } = [];
    public Dictionary<string, int> Ratings { get; set; } = [];
}
