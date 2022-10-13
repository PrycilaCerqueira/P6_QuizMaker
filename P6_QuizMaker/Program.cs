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
                quiz.Answers.AddRange(quizAnswers); //adds to the Answers Object a list of answers from the quizAnswers string - {0 to 4, etc.}
                quizDB.Add(quiz); //adds the quiz instance data entered by the player to the quizBank variable
            }
           
            //Game continuity confirmation
            bool confirmation = UI.WantContinueGame();
            if (confirmation == true)
            {
                Environment.Exit(0);
            }
            UI.PrintGameHeadline(trivia.Title);
            
            //Player Info
            int numOfPlayers = UI.HowManyPlayers();
            List <Player> playersDB = new List<Player>();
            for(int nPlayer = 0; nPlayer < numOfPlayers; nPlayer++)
            {
                Player players = new Player();
                players.ID = UI.GetPlayerInput("\nCreate your in-game ID: ");
                players.Name = UI.GetPlayerInput("Enter your full name: ");
                players.Score = 0;

                playersDB.Add(players);
            }


            //Topics presentation
            
            IEnumerable<string> topics = quizDB.Select(item => item.Topic).Distinct(); //collects all NO repeated topics from the quizBank
            
            while (true)
            {
                UI.PrintGameHeadline(trivia.Title);
                string chosenTopic = UI.SelectATopic(topics); //prints the list of topics to the player
                List<Quiz> questionsOfChosenTopic = quizDB.Where(item => item.Topic == chosenTopic).ToList(); //collects all the questions of the same topic
               
                //Select a random quiz from QuizDB
                int max = questionsOfChosenTopic.Count();
                Random rnd = new Random();

                while (true)
                {
                    int rndIndex = rnd.Next(0, max);
                    Quiz shuffledQuiz = questionsOfChosenTopic[rndIndex]; //Saves aside the rndQuiz to keep the original intact
                    List<string> shuffledAnswers = shuffledQuiz.Answers.OrderBy(item => rnd.Next()).ToList();//Shuffles the rndQuiz answers before presenting them to the players
                    shuffledQuiz.Answers = shuffledAnswers; //Replaces the original shuffledQuiz answers with the shuffledAnswers, so the order of the answers will always different   

                    bool isRightAnswer;
                    if (!shuffledQuiz.Question.Contains("#"))
                    {
                        isRightAnswer = UI.GetPlayerQuizAnswer(shuffledQuiz);

                        if (isRightAnswer == false)
                        {
                            continue;
                        }
                        questionsOfChosenTopic[rndIndex].Question = $"#{questionsOfChosenTopic[rndIndex].Question}"; //Add # to the quiz in the QuizDB to identify as
                    }


                    //break;
                }

                
                //IEnumerable<string> updateTopics
                topics = topics.Where(item => item != chosenTopic);



            }
            

            

            
            
      

        }
    }
}