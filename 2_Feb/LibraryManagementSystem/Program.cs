
namespace LibraryManagementSystem
{
    public class Program
    {
        public static SortedDictionary<int, Book> BookDetails = new SortedDictionary<int, Book>();
        public static void Main(string[] args)
        {
          LibraryUtility library = new LibraryUtility();

            //  Add books
            library.AddBook("The Alchemist", "Paulo Coelho", "Fiction", 1988);
            library.AddBook("Clean Code", "Robert C. Martin", "Programming", 2008);
            library.AddBook("The Pragmatic Programmer", "Andrew Hunt", "Programming", 1999);
            library.AddBook("Brida", "Paulo Coelho", "Fiction", 1990);

            //  Total books count
            Console.WriteLine($"Total Books: {library.GetTotalBooksCount()}");
            Console.WriteLine();

            library.PrintBookDetailsByGenre();
            Console.WriteLine();

            //  Get books by author
            Console.WriteLine("Books by Paulo Coelho:");
            var pauloBooks = library.GetBooksByAuthor("Paulo Coelho");
            foreach (var book in pauloBooks)
            {
                Console.WriteLine($"- {book.Title} ({book.PublicationYear})");
            }

            Console.WriteLine();

            //  Group books by genre
            Console.WriteLine("Books grouped by genre:");
            var groupedBooks = library.GroupBooksByGenre();
            foreach (var genre in groupedBooks)
            {
                Console.WriteLine($"Genre: {genre.Key}");
                foreach (var book in genre.Value)
                {
                    Console.WriteLine($"  - {book.Title} by {book.Author}");
                }
            }

            
        }
    }
}