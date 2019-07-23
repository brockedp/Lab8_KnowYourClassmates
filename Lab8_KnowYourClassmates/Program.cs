using System;

namespace Lab8_KnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] students = { "Mark", "Paul", "Maria", "Laurel", "Adrienne", "Elisha" };
            string[] hometown = { "Arlington Heights, IL", "Grosse Pointe, MI", "Ferndale, MI", "Troy, MI", "Macomb, MI", "Armada, MI" };
            string[] favFood = { "pizza", "steak and potatoes", "grape leaves", "tacos!", "salmon and rice", "sushi" };
            string[] favSport = { "disc golf", "hockey", "basketball", "softball", "golf", "golf" };
            string[] tvShow = { "Game of Thrones", "Breaking Bad", "The Good Place", "The Detour", "The Office", "Rick and Morty" };
            Console.WriteLine("Welcome! Let's get to know some students.");
            bool again = true;
            while (again)
            {
                bool inRange = true;
                int studentNumber = TryCatchInput("Which student would you like to learn about.\nEnter a number (1-6): ");
                if (studentNumber == -100)
                {
                    again = PlayAgain("Would you like try again? (y/n): ");
                }
                else
                {
                    studentNumber--;
                    try
                    {
                        Console.WriteLine(students[studentNumber]);
                        inRange = true;

                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("That number is not within our range.");
                        inRange = false;
                    }
                    if (inRange)
                    {
                        int infoNumber = TryCatchInput("What would you like to know about the student\n1.Hometown\n2.Favorite Food\n" +
                        "3.Favorite Sport\n4.Favorite TV show\nEnter a number (1-4): ");
                        switch (infoNumber)
                        {
                            case 1:
                                Console.WriteLine($"{students[studentNumber]} is from {hometown[studentNumber]}");
                                break;
                            case 2:
                                Console.WriteLine($"{students[studentNumber]}'s favorite food is {favFood[studentNumber]}");
                                break;
                            case 3:
                                Console.WriteLine($"{students[studentNumber]}'s favorite sport is {favSport[studentNumber]}");
                                break;
                            case 4:
                                Console.WriteLine($"{students[studentNumber]}'s favorite TV show is {tvShow[studentNumber]}");
                                break;

                            default:
                                Console.WriteLine("Improper input.");
                                break;
                        }
                        
                        again = PlayAgain("Would you like know more? (y/n): ");

                    }
                    else
                    {
                        again = PlayAgain("Would you like try again? (y/n): ");
                    }
                }

            }
            Console.WriteLine("Have a great day!");
        }

        public static string GetUserInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();

        }
        public static bool PlayAgain(string message)
        {
            string input = "";
            while (input != "y" && input != "yes" && input != "n" && input != "no")
            {
                Console.Write(message);
                input = Console.ReadLine().ToLower();
            }
            
            if(input=="y"|| input == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int TryCatchInput(string message)
        {
            string maybeNumber = GetUserInput(message);
             

            try
            {
                int number = int.Parse(maybeNumber);
                return number;

            }
            catch (FormatException)
            {
                Console.WriteLine("Looks like you did not enter a number.");
                return -100;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Looks like the number you entered was too high or too low.");
                return -100;
            }
            
            catch (Exception e)
            {
                Console.WriteLine("I think you entered bad info.");
                return -100;
            }
        }
            


    }
}
