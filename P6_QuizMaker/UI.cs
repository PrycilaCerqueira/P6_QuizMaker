﻿using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace P6_QuizMaker
{
    internal class UI
    {
        /// <summary>
        /// Prints the art game title 
        /// </summary>
        /// <param name="gameTitle">Name of the game</param>
        public static void PrintGameHeadline(string gameTitle)
        {
            //Console.WriteLine($"Welcome to {gameTitle}");
            Console.Clear();
            Console.WriteLine
                (@"
                      ______     _       _          ____                  __ 
                     /_  __/____(_)   __(_)___ _   / __ \__  _____  _____/ /_
                      / / / ___/ / | / / / __ `/  / / / / / / / _ \/ ___/ __/
                     / / / /  / /| |/ / / /_/ /  / /_/ / /_/ /  __(__  ) /_  
                    /_/ /_/  /_/ |___/_/\__,_/   \___\_\__,_/\___/____/\__/  

                ");

        }


        /// <summary>
        /// Prints the game description on the console for the players
        /// </summary>
        /// <param name="gameDescription">Description of the game</param>
        public static void PrintGameInstructions(string gameDescription)
        {
            Console.WriteLine(gameDescription);
            Console.WriteLine(); //skips a line
        }


        /// <summary>
        /// Gets the number of players
        /// </summary>
        /// <returns>number of players</returns>
        public static int HowManyPlayers()
        {
            string input;
            int numOfPlayers;

            Console.WriteLine("How many people are going to play this time?");
            while (true)
            {
                input = Console.ReadLine().Trim();
                if (String.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Empty or Spaces are invalid entries.");
                    continue;
                }
                if (!int.TryParse(input, out numOfPlayers))
                {
                    Console.WriteLine("This field only accepts numbers.");
                    continue;
                }
                if (numOfPlayers < 1)
                {
                    Console.WriteLine("It is required at least 1 player to continue the game.");
                    continue;
                }
                break;
            }
            return numOfPlayers;
        }

        /// <summary>
        /// Allows the user to enter their inputs to the system
        /// </summary>
        /// <param name="requestHeadline">Question or Resquest</param>
        /// <returns>The answers of the question or request</returns>
        public static string GetPlayerInput(string requestHeadline)
        {
            Console.Write(requestHeadline);
            string playerInput;
            while (true)
            {
                playerInput = Console.ReadLine().ToUpper().Trim();
                if (String.IsNullOrWhiteSpace(playerInput))
                {
                    Console.WriteLine("Empty or Spaces are invalid entries.");
                    Console.Write("Try again: ");
                    continue;
                }
                if (playerInput.Length > 100)
                {
                    Console.WriteLine("The text length cannot be longer than 100 characters.");
                    Console.Write("Try again: ");
                    continue;
                }
                break;
            }
            return playerInput;

        }

        /// <summary>
        /// Confirms whether the player would like to continue the game or not
        /// </summary>
        public static bool WantContinueGame()
        {
            Console.WriteLine("\nWould you like to continue? (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        /// <summary>
        /// It presents the topic entries to the player and asks them to pick one 
        /// </summary>
        /// <param name="topics">List of topics</param>
        /// <returns> The selected topic</returns>
        public static string SelectATopic(IEnumerable<string> topics)
        {
            Console.WriteLine("Here are the topics of your questions: ");
            foreach (var topic in topics)
            {
                Console.WriteLine($" \u00bb {topic}");
            }

            string selectedTopic;
            while (true)
            {
                Console.WriteLine("\nWhich topic would you like to pick? ");
                selectedTopic = Console.ReadLine().Trim().ToUpper();

                if (!topics.Contains(selectedTopic))
                {
                    Console.WriteLine("Your choice isn't listed above. Try again!");
                    continue;
                }
                break;
            }
            return selectedTopic;
        }

        /// <summary>
        /// Prints the Quiz to the player and asks for their answer
        /// </summary>
        /// <param name="item">A set of question and its answers</param>
        /// <returns>The player's chosen answer</returns>
        public static bool GetPlayerQuizAnswer(Quiz item)
        {
            //Prints the question and its answers
            Console.WriteLine();
            Console.WriteLine($"Question: {item.Question}");

            int i = 1;
            foreach(string ans in item.Answers)
            {
                if (ans.Contains("*"))
                {
                    string modifiedAns = ans.Remove(0, 1); //Modifies answer by removing the * element from index 0 with a length of 1. In other words, removes answer's first string element. 
                    Console.WriteLine($"{i}) {modifiedAns}");
                }
                else
                {
                    Console.WriteLine($"{i}) {ans}");
                }
                i++;
            }

            //Gets the player response for the question
            string selectedAnswer;
            int answerNum;

            Console.Write("Which number you choose: ");
            while (true)
            {
                selectedAnswer = Console.ReadLine().Trim();

                if (!int.TryParse(selectedAnswer, out answerNum))
                {
                    Console.WriteLine("This field only accepts a number entry. Try again!");
                    continue;
                }
                if (answerNum < 1 || answerNum > 5)
                {
                    Console.WriteLine("Entry is invalid. Select a number between 1 and 5.");
                    continue;
                }
                break;
            }

            switch (answerNum)
            {
                case 1:
                    selectedAnswer = item.Answers[0];
                    break;
                case 2:
                    selectedAnswer = item.Answers[1];
                    break;
                case 3:
                    selectedAnswer = item.Answers[2];
                    break;
                case 4:
                    selectedAnswer = item.Answers[3];
                    break;
                case 5:
                    selectedAnswer = item.Answers[4];
                    break;
            }

            if (selectedAnswer.Contains("*"))
            {
                return true;
            }
            return false;


        }
        
    }
}

