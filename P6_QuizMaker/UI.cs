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
            Console.WriteLine(); //skip a line
        }

        public static string PrintPlayerInfo(int score)
        {
            string inGameID;

            Console.Write("Create you in-game ID: ");
            inGameID = Console.ReadLine().ToUpper().Trim();

            Console.WriteLine($"Welcome {inGameID}! Your initial score is {score}.");

            return inGameID;
        }
    }
}
