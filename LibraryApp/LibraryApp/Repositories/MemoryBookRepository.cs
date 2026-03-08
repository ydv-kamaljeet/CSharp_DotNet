using LibraryApp.Models;

namespace LibraryApp.Repositories
{
    public class MemoryBookRepository : IBookRepository
    {
        private readonly Dictionary<int, Book> _books;
        private int _nextId;

        public MemoryBookRepository()
        {
            _books = new Dictionary<int, Book>
            {
                [1] = new Book { BookId = 1, Title = "Clean Code", Author = "Robert C. Martin", Price = 499.00m },
                [2] = new Book { BookId = 2, Title = "Design Patterns", Author = "Gang of Four", Price = 699.00m },
                [3] = new Book { BookId = 3, Title = "Refactoring", Author = "Martin Fowler", Price = 549.00m }
            };

            _nextId = 4;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books.Values;
        }

        public Book? GetBookById(int id)
        {
            _books.TryGetValue(id, out var book);
            return book;
        }

        public void AddBook(Book book)
        {
            book.BookId = _nextId++;
            _books[book.BookId] = book;
        }

        public void DeleteBook(int id)
        {
            _books.Remove(id);
        }
    }
}
