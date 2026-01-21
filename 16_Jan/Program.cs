namespace Jan_16;

public class Program
{
    public static void Main()
    {
        FilmLibrary library = new FilmLibrary();

        library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
        library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));

        Console.WriteLine($"Total Movies Right Now : {library.GetTotalFilmCount()}"); // 2

        library.RemoveFilm("Inception");

        Console.WriteLine($"Total Movies Right Now : {library.GetTotalFilmCount()}"); // 1

    }
}