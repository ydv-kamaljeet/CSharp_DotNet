namespace MovieManagement
{
    class Program
    {
        static void Main()
        {
            IFilmLibrary library = new FilmLibrary();

            library.AddFilm(new Film { Title = "Inception", Director = "Christopher Nolan", Year = 2010 });
            library.AddFilm(new Film { Title = "Interstellar", Director = "Christopher Nolan", Year = 2014 });
            library.AddFilm(new Film { Title = "Titanic", Director = "James Cameron", Year = 1997 });

            Console.WriteLine("All Films:");
            foreach (var film in library.GetFilms())
                Console.WriteLine(film.Title);

            Console.WriteLine("\nSearch Result (Nolan):");
            foreach (var film in library.SearchFilms("Nolan"))
                Console.WriteLine(film.Title);

            Console.WriteLine($"\nTotal Films: {library.GetTotalFilmCount()}");

            library.RemoveFilm("Titanic");
            Console.WriteLine($"\nAfter Removal Count: {library.GetTotalFilmCount()}");
        }
    }
}