using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_QuizMaker
{
    internal class UI
    {
        public static void PrintGameInstructions(string gameTitle, string gameDescription)
        {
            Console.WriteLine($"Welcome to {gameTitle}");
            Console.WriteLine(gameDescription);
        }
    }
}
