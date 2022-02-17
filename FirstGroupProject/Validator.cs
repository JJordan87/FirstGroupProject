using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator
{
    internal class Validator
    {
        public static bool GetContinue()
        {
            bool result = true;

            while (true)
            {
                Console.Write("Would you like to continue? y/n");
                string choice = Console.ReadLine();
                if (choice.ToLower().Trim() == "y")
                {
                    result = true;
                    break;
                }
                else if (choice.ToLower().Trim() == "n")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid input.");
                }
            }


            return result;
        }

        //Overloaded version
        public static bool GetContinue(string message)
        {
            bool result = true;

            while (true)
            {
                Console.Write(message);
                string choice = Console.ReadLine();
                if (choice.ToLower().Trim() == "y")
                {
                    result = true;
                    break;
                }
                else if (choice.ToLower().Trim() == "n")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid input.");
                }
            }


            return result;
        }

        public static bool InRange(int value, int min, int max)
        {
            if(value >= min && value <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetUserNumber()
        {
            int result = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter a number.");
                    result = int.Parse(Console.ReadLine());
                    break;
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return result;
        }

    }

}
