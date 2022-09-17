using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_QuizMaker
{
    internal class UI
    {
        /// <summary>
        /// Prints the art game title and the game description on the console for the players
        /// </summary>
        /// <param name="gameTitle">Name of the game<param>
        /// <param name="gameDescription">Description of the game</param>
        public static void PrintGameInstructions(string gameTitle, string gameDescription)
        {
            Console.WriteLine($"Welcome to {gameTitle}");
            Console.WriteLine(gameDescription);
            Console.WriteLine(); //skip a line
        }

        /// <summary>
        /// Prints the player chosen name and their initial score
        /// </summary>
        /// <param name="score">By default the initial score is zero</param>
        /// <returns>The player chosen name</returns>
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
