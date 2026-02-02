using System.Collections.Concurrent;
namespace LibraryManagementSystem
{
    public class LibraryUtility
    {
        private static int ID = 1;
        public void AddBook(string title, string author, string genre, int year)
        {

            Book book = new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                PublicationYear = year
            };
            Program.BookDetails.Add(ID++, book);
        }


        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            SortedDictionary<string, List<Book>> groupedBook = new SortedDictionary<string, List<Book>>();

            foreach (var book in Program.BookDetails.Values)
            {
                if (!groupedBook.ContainsKey(book.Genre))
                {
                    groupedBook[book.Genre] = new List<Book>();
                }
                groupedBook[book.Genre].Add(book);

            }
            //  Sort each genre's book list by Title
            foreach (var book in groupedBook.Values)
            {
                book.Sort();   
            }

            return groupedBook;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> authorsCollection = new List<Book>();
            foreach (var book in Program.BookDetails.Values)
            {
                if (book.Author == author)
                {
                    authorsCollection.Add(book);
                }
            }
            authorsCollection.Sort();
            return authorsCollection;
        }

        public int GetTotalBooksCount()
        {
            return ID - 1;
        }

        public void PrintBookDetailsByGenre()
        {
            foreach (var book in GroupBooksByGenre())
            {
                Console.WriteLine($"{book.Key} Genre have {book.Value.Count()}  books");
            }
        }
    }
}