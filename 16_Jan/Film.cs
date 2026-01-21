namespace Jan_16;

public interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}

public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

public class Film : IFilm
{
    public string? Title{get;set;}
    public string? Director{get;set;}
    public int Year{get;set;}

    public Film(string title, string director,int year)
    {
        Title=title;
        Director=director;
        Year=year;
    }

}

public class FilmLibrary : IFilmLibrary
{
    //Private List of Films
    private List<IFilm> _Films;

    //constructor
    public FilmLibrary()
    {
        _Films = new List<IFilm>();
    }

    //Add Operation:
    public void AddFilm(IFilm film)
    {
        _Films.Add(film);
    }

    //Remove Operation:
    public void RemoveFilm(string title)
    {

        var filmToRemove = _Films.FirstOrDefault(
            f => f.Title.Equals(title, StringComparison.OrdinalIgnoreCase)
        );
        _Films.Remove(filmToRemove);
    }

    //Get Operation:
    public List<IFilm> GetFilms()
    {
        return _Films;  //Return the entire list
    }

    //Search Operation:

    public List<IFilm> SearchFilms(string query)
    {
        return _Films
            .Where(f =>
                f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                f.Director.Contains(query, StringComparison.OrdinalIgnoreCase)
            )
            .ToList();
    }

    public int GetTotalFilmCount()
    {
        return _Films.Count();  //total Size of list
    }
}