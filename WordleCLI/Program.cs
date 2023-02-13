using Wordle;
using static Wordle.WordleClone;

namespace Worlde
{
    class WorldeCLI
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Worlde.");
            WordleClone wordle = new WordleClone();
            bool winnerwinner = false;

            int i = 0;
            while (i < 6)
            {
                winnerwinner = wordle.GuessWord(Console.ReadLine());
                PrintBoard(wordle.Elements);

                if (winnerwinner)
                    break;

                i++;
            }

            if (winnerwinner)
                Console.WriteLine($"Correct!");
            else
                Console.WriteLine("Game over!");

        }

        static void PrintBoard(List<List<Element>> elements)
        {
            Console.Clear();

            foreach(var word in elements)
            {
                foreach(var element in word)
                {
                    switch (element.Accuracy)
                    {
                        case Accuracy.Correct:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case Accuracy.Close:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case Accuracy.Invalid:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                    }

                    Console.Write(element.Letter);
                }

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}