using System;
using Services;
using Domain;
using Exceptions;
namespace ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MedicineUtility util = new MedicineUtility();

            while (true)
            {
                Console.WriteLine("1. Display Medicines");
                Console.WriteLine("2. Update Medicine Price");
                Console.WriteLine("3. Add Medicine");
                Console.WriteLine("4. Exit");

                // TODO: Read user choice
                string? input = Console.ReadLine();
                int choice = int.Parse(input); 
                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        try{
                            util.PrintMedicines(util.GetAllMedicines());
                        }
                        catch(MedicineNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        // TODO: Update price
                        try{
                            string? id = Console.ReadLine();
                            int newPrice = int.Parse(Console.ReadLine());
                            util.UpdateMedicinePrice(id,newPrice);
                        }
                        catch(InvalidPriceException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        // TODO: Add Medicine
                        try{
                            string? Id = Console.ReadLine();
                            string? name = Console.ReadLine();
                            int price = int.Parse(Console.ReadLine());
                            int expiry = int.Parse(Console.ReadLine());
                            Medicine med = new Medicine(Id,name,price,expiry);
                            util.AddMedicine(med);
                        }
                        catch(DuplicateMedicineException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch(InvalidExpiryYearException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid Choice Input");
                        break;
                }
            }
        }
    }
}
