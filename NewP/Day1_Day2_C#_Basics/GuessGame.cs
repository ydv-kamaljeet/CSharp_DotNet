using System;

namespace kamaljeet;

class GuessGame
{
    public void StartGame(int num)
    {
        int usInput=0;
        do
        {
            string? input = Console.ReadLine();
            
            //Trying to parse string to integer,if user enter something else that cannt be parsed to string it will ask to enter valid input.
            if(!int.TryParse(input, out usInput))
            {
                Console.WriteLine("Enter valid number.");
            }
        }while(usInput!=num);

        Console.WriteLine("You Won!!!!");
        
    }
}
