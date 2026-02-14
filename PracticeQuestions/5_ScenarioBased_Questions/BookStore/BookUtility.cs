namespace BookStore
{
    public class BookUtility
    {
        private Book _book;
        public BookUtility(Book book)   //class object injection
        {
            this._book = book;
        }

        public void GetBookDetails()
        {
            Console.WriteLine($"Book Id : {_book.Id}  |  Title : {_book.Title}  |  Price : {_book.Price}  |  Stock : {_book.Stock}");
        }

        public void UpdateBookPrice(int newPrice)
        {
            _book.Price = newPrice;
        }
        public void UpdateBookStock(int newStock)
        {
            _book.Stock = newStock;
        }
    }
}