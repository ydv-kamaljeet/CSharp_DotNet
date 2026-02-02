namespace LibraryManagementSystem
{
    public class Book : IComparable<Book>
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int PublicationYear { get; set; }

        public int CompareTo(Book other)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(this.Title, other.Title);
        }
    }
}