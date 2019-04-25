using System;

namespace Dice_Roll
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random object to get a random number.
            Random rnd = new Random();
            //bool for do while
            bool rollAgain = false;

            //Allow user to play game more than once.
            do
            {
                //Get number of sides on the dice(Max Number)
                int sides = GetValidInteger("Enter the number of sides for a dice: ");
                //Get number of dice to roll
                int dice = GetValidInteger("Enter the number of dice: ");
                //Roll the dice and display the total of dice rolled
                Roll(sides, dice, rnd);
                //Do you want to roll again?
                rollAgain = Continue();
            } while (rollAgain);
        }

        /// <summary>
        /// Gets a integer and will display message to user asking for a integer and ensure we get a integer
        /// </summary>
        /// <param name="message">Message to display asking for a integer</param>
        /// <returns>the valid integer</returns>
        static int GetValidInteger(string message)
        {
            Console.Write(message);
            string userInput = Console.ReadLine().Trim();

            bool isValid = int.TryParse(userInput, out int validInteger);

            if (!isValid)
            {
                if (!message.Contains("Hey that is not a valid number!"))
                {
                    message = "Hey that is not a valid number! " + message;
                }
                validInteger = GetValidInteger(message);
            }
            return validInteger;
        }

        /// <summary>
        /// Returns a random number between 1 and max + 1
        /// </summary>
        /// <param name="max">int</param>
        /// <param name="rnd">Random object</param>
        /// <returns></returns>
        public static int GetRandom(int max, Random rnd)
        {
            return rnd.Next(1, max + 1);
        }

        /// <summary>
        /// Gets random based on sides and number of dice then sums those together.
        /// </summary>
        /// <param name="sides">int - Max number for random number</param>
        /// <param name="dice">int - number of times to get random number</param>
        /// <param name="rnd">Random Object - Generated at start of program to avoid quirky random numbers</param>
        /// <returns></returns>
        public static int Roll(int sides, int dice, Random rnd)
        {
            int total = 0;
            //Roll equal to number of dice
            for (int i = 0; i < dice; i++)
            {
                total += GetRandom(sides, rnd);
            }

            //Display results
            if (total == 2)
            {
                Console.WriteLine("You rolled: " + total + " \'Snake Eyes!\'");

            }
            else if (total == 12)
            {
                Console.WriteLine("You rolled: " + total + " \'Box Cars!\'");
            }
            else
            {
                Console.WriteLine("You rolled: " + total);
            }

            return total;
        }

        /// <summary>
        /// Gets users input for question of if they want to Roll Again. It validates the response.
        /// </summary>
        /// <returns>bool</returns>
        public static bool Continue()
        {
            Console.WriteLine("Roll Again? Y/N");
            string input = Console.ReadLine().Trim().ToLower();
            bool run = false;

            if (input == "n" || input == "no")
            {
                Console.WriteLine("Good bye");
                run = false;
            }
            else if (input == "y" || input == "yes")
            {
                run = true;
            }
            else
            {
                Console.WriteLine("I don't understand. Try again!");
                run = Continue();
            }
            return run;
        }
    }
}
