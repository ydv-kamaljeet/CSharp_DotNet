namespace MovieManagement
{
    public class Film : IFilm
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

    }


    public class FilmLibrary : IFilmLibrary
    {
        private List<IFilm> _films;

        public FilmLibrary()
        {
            _films = new List<IFilm>();
        }


        public void AddFilm(IFilm film)
        {
            _films.Add(film);
        }


        public void RemoveFilm(string title)
        {
            var ff = _films.FirstOrDefault(t => t.Title == title);
                
            if(ff != null)
            {
                _films.Remove(ff);
            }
            
           
        }

        public List<IFilm> GetFilms()
        {
            return new List<IFilm>(_films);
          
        }
        public List<IFilm> SearchFilms(string query)
        {
            List<IFilm> result = new List<IFilm>();
            foreach (var film in _films)
            {
                var f = film as Film;

                if (film.Title.Contains(query) ||
                    (f != null && f.Director.Contains(query)))
                {
                    result.Add(film);
                }
            }
            return result;
        }

        public int GetTotalFilmCount()
        {
            return _films.Count();
        }

    }

}