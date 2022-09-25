using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            //Console.WriteLine($"Welcome to {gameTitle}");
            Console.WriteLine
                (@"
                      ______     _       _          ____                  __ 
                     /_  __/____(_)   __(_)___ _   / __ \__  _____  _____/ /_
                      / / / ___/ / | / / / __ `/  / / / / / / / _ \/ ___/ __/
                     / / / /  / /| |/ / / /_/ /  / /_/ / /_/ /  __(__  ) /_  
                    /_/ /_/  /_/ |___/_/\__,_/   \___\_\__,_/\___/____/\__/  

                ");
            Console.WriteLine(gameDescription);
            Console.WriteLine(); //skips a line
        }

        /// <summary>
        /// Prints the player chosen name and their initial score
        /// </summary>
        /// <param name="score">By default the initial score is zero</param>
        /// <returns>The player chosen name</returns>
        public static string PrintPlayerInfo(int score)
        {
            string inGameID;

            Console.Write("Create your in-game ID: ");
            inGameID = InputVerification();

            Console.WriteLine($"Welcome {inGameID}! Your initial score is {score}.");

            return inGameID;
        }



        //Quiz Input Block
        public static string TopicInput()
        {
            string topic;
            Console.WriteLine(); //skips a line
            Console.Write("Enter the question topic: ");
            topic = InputVerification();
            return topic;
        }
        public static string QuestionInput()
        {
            string question;
            Console.Write("Enter your question: ");
            question = InputVerification();
            return question;
        }
        public static string AnswersInput()
        {
            string answer;
            Console.Write("Enter your answer: ");
            answer = InputVerification();
            return answer;
        }
        public static string RightAnswerInput()
        {
            string answer;
            Console.Write("Enter right answer to your question: ");
            answer = InputVerification();
            return answer;
        }
        static string InputVerification()
        {
            string txtInput;

            while (true)
            {
                txtInput = Console.ReadLine().ToUpper().Trim();

                if (String.IsNullOrWhiteSpace(txtInput))
                {
                    Console.WriteLine("Empty or Spaces are invalid entries.");
                    Console.Write("Try again: ");
                    continue;
                }
                if (txtInput.Length > 100)
                {
                    Console.WriteLine("The text length cannot be longer than 100 characters.");
                    Console.Write("Try again: ");
                    continue;
                }
                break;
            }
            return txtInput;
        }
    }
}
