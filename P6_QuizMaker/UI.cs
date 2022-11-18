﻿using System.Linq;
using System.Runtime.CompilerServices;
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
        /// Allows the players to create their Quiz Cards to play the game
        /// </summary>
        /// <returns>A list of Quiz Cards</returns>
        public static List<Quiz> GetQuizCards()
        {
            List<Quiz> quizCardsDB = new List<Quiz>(); //The quizBank variable holds a list type Quiz
            for (int numOfQuestions = 0; numOfQuestions < 3; numOfQuestions++) //limits the number of questions that the player will input
            {
                Quiz quizCard = new Quiz(); //Created and initiated an instance of the my Quizzes object to be populated by the player 
                quizCard.Topic = GetPlayerInput("\nEnter the question topic: ");
                quizCard.Question = GetPlayerInput("Enter the question: ");

                List<string> quizAnswers = new List<string>(); //creates a local list of answers to be added to the object QuizAnswers list later

                quizAnswers.Add(GetPlayerInput("Enter the right answer: "));
                quizAnswers[0] = $"*{quizAnswers[0]}"; //The correct answers will be identified by the symbol *

                for (int numOfAnswers = 0; numOfAnswers < 4; numOfAnswers++)
                {
                    quizAnswers.Add(GetPlayerInput($"Enter an answer: "));
                }
                quizCard.Answers.AddRange(quizAnswers); //adds to the Answers Object a list of answers from the quizAnswers string - {0 to 4, etc.}
                quizCardsDB.Add(quizCard); //adds the quiz instance data entered by the player to the quizBank variable
            }
            return quizCardsDB;
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
        /// Allows the players to enter their Nicknames and Names
        /// </summary>
        /// <param name="numOfPlayers">Number of Players</param>
        /// <returns>A list of Players info</returns>
        public static List<Player> GetPlayersInfo(int numOfPlayers)
        {
            List<Player> playersDB = new List<Player>();
            for (int nPlayer = 0; nPlayer < numOfPlayers; nPlayer++)
            {
                Player players = new Player();

                players.Name = UI.GetPlayerInput("Enter your full name: ");
                players.Score = 0;

                playersDB.Add(players);
            }
            return playersDB;
        }


        /*
        /// <summary>
        /// It presents the topic entries to the player and asks them to pick one 
        /// </summary>
        /// <param name="topics">List of topics</param>
        /// <returns> The selected topic</returns>
        public static string SelectATopic(List<string> topics)
        {
            string selectTopic;
            int selectTopicNumber;

            Console.WriteLine("\nSelect one option from: ");
            for (int top = 0; top < topics.Count(); top++)
            {
                Console.WriteLine($"{top + 1}) {topics[top]}");
            }

            while (true)
            {
                Console.Write("Enter option number: ");
                selectTopic = Console.ReadLine().Trim();

                if (!int.TryParse(selectTopic, out selectTopicNumber))
                {
                    Console.WriteLine("This field only accepts a number entry. Try again!");
                    continue;
                }
                if (selectTopicNumber > topics.Count())
                {
                    Console.WriteLine("The entry is invalid! Pick a valid number.");
                    continue;
                }
                break;

            }

            var currentPlayer = topics.ElementAt(selectTopicNumber - 1); //Gets the player info based on the list index because playerTurnID is a number at this point
            return currentPlayer; //returns the currentPlayer info
        }
        */



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

            selectedAnswer = item.Answers[answerNum - 1]; //Reference the menu number to the question (string)
           
            if (selectedAnswer.Contains("*"))
            {
                return true;
            }
            return false;


        }

        /*
        /// <summary>
        /// Allows the player to select whose turn is it
        /// </summary>
        /// <param name="playersDB">List of players</param>
        /// <returns>the player's turn info </returns>
        public static Player WhoseTurnIsThis(List<Player> playersDB)
        {
            string playerTurnID;
            int turnNum;

            List<string> displayPlayersIDs = playersDB.Select(p => p.Nickname).Distinct().ToList();
            Console.WriteLine("\nWhose turn is this? ");
            for (int turnN = 0; turnN < displayPlayersIDs.Count(); turnN++)
            {
                Console.WriteLine($"{turnN + 1}) {displayPlayersIDs[turnN]}");
            }

            while (true)
            {
                Console.Write("Enter ID number: ");
                playerTurnID = Console.ReadLine().Trim();

                if (!int.TryParse(playerTurnID, out turnNum))
                {
                    Console.WriteLine("This field only accepts a number entry. Try again!");
                    continue;
                }
                if (turnNum > displayPlayersIDs.Count())
                {
                    Console.WriteLine("The entry is invalid! Pick a valid number.");
                    continue;
                }
                break;

            }

            Player currentPlayer = playersDB.ElementAt(turnNum - 1); //Gets the player info based on the list index because playerTurnID is a number at this point
            return currentPlayer; //returns the currentPlayer info
        }
        */

        public static T SelectOption<T>(List<T> genericList) //Generic Method
        {
            
            List<T> FilteredList = new List<T>();
            string strValue;
            int numValue;

            if (typeof(T) == typeof(Player))
            {
                
                FilteredList = genericList.Select(p => p.Name).Distinct().ToList();
                
                for (int i = 0; i < FilteredList.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}) {FilteredList[i]}");
                }
                Console.WriteLine("\nWhose turn is this? ");
            }
            else if (typeof(T) == typeof(String))
            {
                for (int i = 0; i < FilteredList.Count(); i++)
                {
                    Console.WriteLine($"{i + 1}) {FilteredList[i]}");
                }
                Console.WriteLine("\nWhich topic you chose? ");

            }

            while (true)
            {
                Console.Write("Enter number: ");
                strValue = Console.ReadLine().Trim();

                if (!int.TryParse(strValue, out numValue))
                {
                    Console.WriteLine("This field only accepts a number entry. Try again!");
                    continue;
                }
                if (numValue > FilteredList.Count())
                {
                    Console.WriteLine("The entry is invalid! Pick a valid number.");
                    continue;
                }
                break;

            }

            var currentValue = genericList.ElementAt(numValue - 1); //Gets the player info based on the list index because playerTurnID is a number at this point
            return currentValue; //returns the currentPlayer info
        }


        /// <summary>
        /// Prints the players' final scores on the console
        /// </summary>
        /// <param name="playersDB">List of players' info</param>
        public static void PrintPlayersFinalScore(List<Player> playersDB)
        {
            Console.WriteLine("*** Players' Scores ***");
            foreach (var player in playersDB)
            {
                Console.WriteLine($"\n  Player name: {player.Name}\n  Final score: {player.Score}");
            }

        }
    }
}

