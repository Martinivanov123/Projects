using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main()
        {
            int score = 0;

            while (true)
            {
                score += Game();
                Console.WriteLine("Score: {0}", score);
                Console.WriteLine();
                Console.WriteLine("Do you wish to play again? Answer with yes or no");
                string answer = Console.ReadLine();

                if (answer == "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("Final score: {0}", score);
                    Console.WriteLine("Goodbye!");
                    Console.WriteLine();
                    break;
                }

                while (answer != "yes" && answer != "no")
                {
                    Console.WriteLine("Invalid answer! Please, answer with yes or no!");
                    answer = Console.ReadLine();
                }
            }
        }

        static int Game()
        {
            Menu();

            int level = int.Parse(Console.ReadLine());
            int sanctions = 0;
            bool win = false;

            while (level < 1 || level > 3)
            {
                Console.WriteLine("The level you want to play does not exist. Try again!");
                Console.Write("Please, enter your level: ");
                level = int.Parse(Console.ReadLine());
            }

            int max = GetMaxNum(level);
            int rand = GenNum(max);
            int attempts = returnAttempts(level);

            Console.WriteLine("WELCOME TO THE GAME! YOU HAVE {0} ATTEMPTS", attempts);
            Console.WriteLine();
            Console.WriteLine();

            while (attempts > 0 && !win)
            {
                Console.Write("Enter your number: ");
                int number = int.Parse(Console.ReadLine());

                while (number < 0 || number > max)
                {
                    Console.Write("The allowed range is [{0} - {1}]! Please, enter again: ", 0, max);
                    sanctions++;
                    number = int.Parse(Console.ReadLine());
                }

                if (CorrectGuess(number, rand))
                {
                    Console.WriteLine("CONGRATULATIONS! YOU WON THE GAME!!!!1!!11!!11!!");
                    win = true;
                }

                else
                {
                    attempts--;
                    if (attempts > 0)
                    {
                        Console.WriteLine("WRONG!!! YOU HAVE {0} ATTEMPTS LEFT", attempts);
                        if (rand < number)
                        {
                            Console.WriteLine("The guess is higher");
                        }

                        else
                        {
                            Console.WriteLine("The guess is lower");
                        }
                    }

                    else if (attempts == 0)
                    {
                        Console.WriteLine("GAME OVER!!! YOU LOST! THE NUMBER WAS {0}!", rand);
                    }

                }
            }
            Console.WriteLine();
            Console.WriteLine();

            return Result(attempts, sanctions);
        }

        static int Result(int attempts, int sanctions)
        {
            int result = attempts * 10 - sanctions * 5;
            return result;
        }

        static void Menu()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("========= GUESS THE NUMBER =========");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("PLEASE SELECT LEVEL:");
            Console.WriteLine();
            Console.WriteLine("1. LEVEL 1 - Guess a number from 0 to 10 in 3 attempts (1)");
            Console.WriteLine("2. LEVEL 2 - Guess a number from 0 to 20 in 6 attempts (2)");
            Console.WriteLine("3. LEVEL 3 - Guess a number from 0 to 30 in 9 attempts (3)");
            Console.WriteLine();
            Console.Write("Please, enter your level: ");
        }

        static int GenNum(int end)
        {
            Random rand = new Random();
            return rand.Next(end);
        }

        static int GetMaxNum(int level)
        {
            int max = level * 10;
            return max;
        }

        static int returnAttempts(int level)
        {
            int attempts = level * 3;
            return attempts;
        }

        static bool CorrectGuess(int number, int rand)
        {
            if (number == rand)
            {
                return true;
            }
            return false;
        }
    }
}
