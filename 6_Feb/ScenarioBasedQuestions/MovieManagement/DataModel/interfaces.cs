namespace MovieManagement
{
    public interface IFilm
    {
        string Title{get;}
    }

    public interface IFilmLibrary
    {
        void AddFilm(IFilm film);
        void RemoveFilm(string title);
        List<IFilm> GetFilms();		
        List<IFilm>	SearchFilms(string query);
        int GetTotalFilmCount();

    }
}