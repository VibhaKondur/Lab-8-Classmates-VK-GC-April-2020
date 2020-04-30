using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace GC_Lab_8_Classmates_VK_4_30_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Olivia", "Fitz", "Mellie", "Abby", "Quinn", "Diego" };
            string[] favoriteFoods = { "popcorn", "steak", "chicken", "veggies", "chili", "potatoes" };
            string[] homestate = { "Washington DC", "Georgia", "North Carolina", "Virginia", "California", "Texas" };
            string[] favoriteAlcohol = { "wine", "any liquor", "moonshine", "scotch", "beer", "whiskey" };
            string[] favoriteBar = { "Round Robin", "The Vortex", "Alley Twenty Six", "Calypso", "Yard House", "The Menger Bar" };

            Console.WriteLine("Welcome to the Student Database!");


            int index = -1;
            bool validInput = false;
            bool runAgain = true;
            string runAgainstring = "";
            string name = "";

            while (runAgain)
            {

                index = -1;
                name = "";
                validInput = false;

                while (!validInput)
                {
                    Console.WriteLine("Do you want to search by student name or number? Enter 1 for name or 2 for number");
                    string response = Console.ReadLine();

                    switch (response)
                    {
                        case "1":
                            Console.WriteLine("Great! What's the student's name?");
                            string answer = Console.ReadLine();
                            index = GetIndexByUserName(answer, names);
                            break;

                        case "2":
                            Console.WriteLine("Great! What's the student's number?");
                            DisplayUsers(names);
                            Console.WriteLine($"Please select a number from 0 to {names.Length - 1}");
                            string input = Console.ReadLine().ToLower();
                            index = VerifyNumber(input);
                            break;
                        default:
                            Console.WriteLine("Invalid selection");
                            break;
                    }

                    if(VerifyIndex(names, index))
                    {
                        name = names[index];
                        validInput = true;
                    }
                }

                if (name != "")
                {
                    Console.WriteLine($"You selected {name} at index: {index}");
                    Console.WriteLine($"What would you like to learn about {name}? Type (ff) for their favorite food, (hs) for their home state, (fa) for their favorite alcohol, or (fb) for their favorite bar. ");

                    string response = Console.ReadLine();

                    if (response == "ff")
                    {
                        Console.WriteLine($"The favorite food of {name} is {favoriteFoods[index]}");
                    }
                    else if (response == "hs")
                    {
                        Console.WriteLine($"The homestate of {name} is {homestate[index]}");
                    }
                    else if (response == "fa")
                    {
                        Console.WriteLine($"The favorite alcohol of {name} is {favoriteAlcohol[index]}");
                    }
                    else if (response == "fb")
                    {
                        Console.WriteLine($"The favorite bar of {name} is {favoriteBar[index]}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry that is not a valid response.");
                    }

                }

                Console.WriteLine($"Do you want to learn about another student? y/n");

                runAgainstring = Console.ReadLine().ToLower();

                if (runAgainstring == "y")
                {
                    Console.WriteLine($"Great! Which other student do you want to learn about?");
                    //Console.WriteLine($"Great! To learn more about {name} , input (ff) for their favorite food, (hs) for their home state, (fa) for their favorite alcohol, or (fb) for their favorite bar. ");
                    runAgain = true;
                }

                else
                {
                    Console.WriteLine("No problem. Have a great day!");
                    break;
                }
            }
        }

        public static int GetIndexByUserName(string name, string[] names)
        {
            for (int i = 0; i <= names.Length; i++)
            {
                if (name == names[i].ToLower())
                {
                    return i;
                }
            }
            return -1;
        }

        public static void DisplayUsers(string[] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i}: {names[i]}");
            }
        }

        public static int VerifyNumber(string input)
        {
            try
            {
                int number = int.Parse(input);
                return number;
            }
            catch (FormatException)
            {                
                Console.WriteLine("This is not a number please try again!");
                input = Console.ReadLine();
                return VerifyNumber(input);
            }
        }

        public static bool VerifyIndex(string[] names, int index)
        {
            try
            {
                string name = names[index];
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"that number is outside the range of 0 to {names.Length - 1}");
                return false;
            }
        }

        //public static string LearnMoreInfo(string[] favoriteFoods, string[] homestate, string[] favoriteAlcohol, string[] favoritebar)
        //{
            //if (input = )
        //}
        

    }
}
