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
            GameInfo trivia = new GameInfo();
            UI.PrintGameHeadline(trivia.Title);
            UI.PrintGameInstructions(trivia.Description);

            //Quiz DB Creation
            List<Quiz> quizDB = UI.GetQuizCards();
           
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


            //Topic presentation
            while (true) 
            {
                UI.PrintGameHeadline(trivia.Title);
                IEnumerable<string> topics = quizDB.Select(item => item.Topic).Distinct(); //collects all NO repeated topics from the quizBank
                
                string chosenTopic = UI.SelectATopic(topics); //prints the list of topics to the player
                List<Quiz> questionsOfChosenTopic = quizDB.Where(item => item.Topic == chosenTopic).ToList(); //collects all the questions of the same topic
               
                                                             //TODO: Ask for the first player 

                //Select a random quiz from QuizDB
                int max = questionsOfChosenTopic.Count();
                Random rnd = new Random();


                //Quiz presentation
                while (max >= 1)
                {
                    int rndIndex = rnd.Next(0, max);
                    Quiz shuffledQuiz = questionsOfChosenTopic[rndIndex]; //Saves aside the rndQuiz to keep the original intact
                    
                    List<string> shuffledAnswers = shuffledQuiz.Answers.OrderBy(item => rnd.Next()).ToList();//Shuffles the rndQuiz answers before presenting them to the players
                    shuffledQuiz.Answers = shuffledAnswers; //Replaces the original shuffledQuiz answers with the shuffledAnswers, so the order of the answers will always different   


                    //Players' score calc 
                    bool isRightAnswer = UI.GetPlayerQuizAnswer(shuffledQuiz);
                    if (isRightAnswer == true)
                    {
                        questionsOfChosenTopic.Remove(shuffledQuiz); //Deletes the quiz from my filtered list (inner while)
                        quizDB.Remove(shuffledQuiz); //Deletes the quiz from my main list (outer while)
                        max--;

                                                            //TODO: Calculate the player's score
                    }
                                                            //TODO: If the answer wasn't right, replace player for the next one
                }

                if (topics.Count() < 1)
                {
                    break;
                }

            }
            //TODO: Calculate the final score of the players
            
        

            
            
      

        }
    }
}