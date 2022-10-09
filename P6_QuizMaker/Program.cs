using System;
using System.ComponentModel.DataAnnotations;
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
            List<Quiz> quizDB = new List<Quiz>(); //The quizBank variable holds a list type Quiz
            for (int numOfQuestions = 0; numOfQuestions < 3; numOfQuestions++) //limits the number of questions that the player will input
            {
                Quiz quiz = new Quiz(); //Created and initiated an instance of the my Quizzes object to be populated by the player 
                quiz.Topic = UI.GetPlayerInput("\nEnter the question topic: ");
                quiz.Question = UI.GetPlayerInput("Enter the question: ");
               
                List <string> quizAnswers = new List<string>(); //creates a local list of answers to be added to the object QuizAnswers list later
                for (int numOfAnswers = 0; numOfAnswers < 5; numOfAnswers++)
                {
                    if (numOfAnswers != 0)
                    {
                        quizAnswers.Add(UI.GetPlayerInput($"Enter an answer: "));
                    }
                    else
                    {
                        quizAnswers.Add(UI.GetPlayerInput("Enter the right answer: "));
                        quizAnswers[0] = $"*{quizAnswers[0]}"; //The correct answers will be identified by the symbol *
                    }                   
                }
                quiz.QuizAnswers.AddRange(quizAnswers); //adds the QuizAnswers Object list a range of answers from the quizAnswers string list - {0 to 4}
                quizDB.Add(quiz); //adds the quiz instance data entered by the player to the quizBank variable
            }

            //quiz.Answer2 = UI.GetPlayerInput("Enter your answer 2: ");
            //quiz.Answer3 = UI.GetPlayerInput("Enter your answer 3: ");
            //quiz.Answer4 = UI.GetPlayerInput("Enter your answer 4: ");

        
            
            //Game continuity confirmation
            bool confirmation = UI.WantContinueGame();
            if (confirmation == true)
            {
                Environment.Exit(0);
            }
            UI.PrintGameHeadline(trivia.Title);
            
            //Player Info
            int numOfPlayers = UI.HowManyPlayers();
            
            var playersDB = new List<Player>();
            for(int nPlayer = 0; nPlayer < numOfPlayers; nPlayer++)
            {
                Player players = new Player();
                players.ID = UI.GetPlayerInput("\nCreate your in-game ID: ");
                players.Name = UI.GetPlayerInput("Enter your full name: ");
                players.Score = 0;

                playersDB.Add(players);
            }

            //Topics presentation
            UI.PrintGameHeadline(trivia.Title);
            IEnumerable<string> topics = quizDB.Select(item => item.Topic).Distinct(); //collects all no repeated topics from the quizBank
            string chosenTopic = UI.SelectATopic(topics); //prints the list of topics to the player
            List<Quiz> QuestionsOfChosenTopic = quizDB.Where(item => item.Topic == chosenTopic).ToList(); //collects all the questions of the same topic

            //TODO: Sort and retreive 1 question with its answers to present to the player
            int max = QuestionsOfChosenTopic.Count();
            Random rnd = new Random();
            int rndIndex = rnd.Next(0, max);
            Quiz shuffledQuiz = QuestionsOfChosenTopic[rndIndex];          
            
            string playerAnswer;
            if(shuffledQuiz.Question != $"*{shuffledQuiz.Question}")
            {
                playerAnswer = UI.GetPlayerQuizAnswer(shuffledQuiz);

                //TODO: Mark as used quiz in the QuizDB (test) 
                QuestionsOfChosenTopic[rndIndex].Question = $"*{QuestionsOfChosenTopic[rndIndex].Question}";

            }
                        
            
      

        }
    }
}