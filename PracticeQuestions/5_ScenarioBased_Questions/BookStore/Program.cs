using System.Diagnostics;
using System;
namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the book details : ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if(parts.Length != 4)
            {
                Console.WriteLine("Invalid Input.");
                return;
            }
            Book book = new Book{Id = parts[0] , Title = parts[1] , Price = int.Parse(parts[2]) , Stock = int.Parse(parts[3])};
            BookUtility util = new BookUtility(book);
            while (true)
            {
                Console.WriteLine("1. Display Details of book.\n2. Update Book Price.\n3. Update Stock of book.\n4. Exit");
                Console.WriteLine("Enter Choice : ");
                
                string strChoice = Console.ReadLine();
                string[] part = strChoice.Split(' ');
                if(part.Length == 1)
                {
                    if (part[0] == "1")
                    {
                        util.GetBookDetails();
                    }else if(part[0] == "4")
                    {
                        return;
                    }
                }else if (part.Length == 2)
                {
                    if(part[0] == "2")
                    {
                        util.UpdateBookPrice(int.Parse(part[1]));
                    }else if (part[0] == "3")
                    {
                        util.UpdateBookStock(int.Parse(part[1]));
                    }
                }
                else
                    Console.WriteLine("Invalid Input");
                
            }
            

        }
    }
}