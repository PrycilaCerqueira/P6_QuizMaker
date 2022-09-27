using System;
using System.Linq;

namespace P6_QuizMaker // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Game Info
            Game trivia = new Game();
            UI.PrintGameHeadline(trivia.Title);
            UI.PrintGameInstructions(trivia.Description);
            
            //Quiz DB Creation
            var quizBank = new List<Quizzes>(); //The quizBank variable holds a list type Quiz
            for(int numOfQuestions = 0; numOfQuestions < 3; numOfQuestions++) //limits the number of questions that the player will input
            {
                Quizzes quiz = new Quizzes(); //Created and initiated an instance of the my Quiz object to populated by the player 
                quiz.Topic = UI.GetPlayerInput("\nEnter the question topic: ");
                quiz.Question = UI.GetPlayerInput("Enter the question: ");
                quiz.Answer1 = UI.GetPlayerInput("Enter your answer 1: ");
                quiz.Answer2 = UI.GetPlayerInput("Enter your answer 2: ");
                quiz.Answer3 = UI.GetPlayerInput("Enter your answer 3: ");
                quiz.Answer4 = UI.GetPlayerInput("Enter your answer 4: ");
                quiz.CorrectAnswer = UI.GetPlayerInput("Enter right answer to your question: ");

                quizBank.Add(quiz); //adds the the quiz instance data entered by the player to the quizBank variable
            }

            //Game continuity confirmation
            UI.wantContinueGame();
            UI.PrintGameHeadline(trivia.Title);
            
            //Player Info
            int numOfPlayers = UI.HowManyPlayers();
            var playersBank = new List<Players>();
            for(int nPlayer = 0; nPlayer < numOfPlayers; nPlayer++)
            {
                Players player = new Players();
                player.ID = UI.GetPlayerInput("\nCreate your in-game ID: ");
                player.Name = UI.GetPlayerInput("Enter your full name: ");
                player.Score = 0;

                playersBank.Add(player);
            }

            //Game continuity confirmation
            UI.wantContinueGame();
            UI.PrintGameHeadline(trivia.Title);

            //Preset the topics of the questions to the players https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.distinct?view=net-7.0
            var topics = from item in quizBank
                            where item.Topic != null
                            select item.Topic; //collects all the topics from the quizBank
            var noDuplicates = topics.Distinct().ToList(); //filters the topics to not show duplicated entries
            string chosenTopic = UI.SelectATopic(noDuplicates); //prints the list of noDuplicated topics to the player

                

            




            










        }
    }
}