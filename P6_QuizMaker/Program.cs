using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace P6_QuizMaker // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO: BONUS: Update stored the Q/A in a file and restore them.

            bool confirmation;
            Random rnd = new Random();

            do
            {
                //Game Info
                GameInfo trivia = new GameInfo();
                UI.PrintGameHeadline(trivia.Title);
                UI.PrintGameInstructions(trivia.Description);

                //Quiz DB Creation
                List<Quiz> quizDB = UI.GetQuizCards();
                XML.ExportFile(quizDB);

                //Game continuity confirmation
                confirmation = UI.WantContinueGame();
                if (confirmation == true)
                {
                    Environment.Exit(0);
                }
                UI.PrintGameHeadline(trivia.Title);

                //Player Info
                int numOfPlayers = UI.HowManyPlayers();
                List<Player> playersDB = UI.GetPlayers(numOfPlayers);

                //Topic presentation
                while (true)
                {
                    UI.PrintGameHeadline(trivia.Title);
                    
                    List<string> topics = quizDB.Select(item => item.Topic).Distinct().ToList(); //collects all NO repeated topics from the quizBank
                    if (topics.Count() < 1)
                    {
                        break;
                    }

                    string chosenTopic = UI.SelectATopic(topics); //prints the list of topics to the player
                    List<Quiz> questionsOfChosenTopic = quizDB.Where(item => item.Topic == chosenTopic).ToList(); //collects all the questions of the same topic

                    Player currentPlayer = UI.WhoseTurnIsThis(playersDB); //Confirms the name of the player's turn
                    int max = questionsOfChosenTopic.Count();

                    //Quiz presentation
                    while (max >= 1)
                    {
                        int rndIndex = rnd.Next(0, max);
                        Quiz shuffledQuiz = questionsOfChosenTopic[rndIndex]; //Saves aside the rndQuiz to keep the original intact

                        List<string> shuffledAnswers = shuffledQuiz.Answers.OrderBy(item => rnd.Next()).ToList();//Shuffles the rndQuiz answers before presenting them to the players
                        shuffledQuiz.Answers = shuffledAnswers; //Replaces the original shuffledQuiz answers with the shuffledAnswers, so the order of the answers will always different   


                        //Players' score calc 
                        bool isRightAnswer = UI.GetPlayerQuizAnswer(shuffledQuiz);
                        if (isRightAnswer == false) //If the answer wasn't right, replace player for the next one
                        {
                            break;
                        }

                        currentPlayer.Score = currentPlayer.Score + 10;//Calculates the player's score
                        questionsOfChosenTopic.Remove(shuffledQuiz); //Deletes the quiz from my filtered list (inner while)
                        quizDB.Remove(shuffledQuiz); //Deletes the quiz from the main list (outer while)
                        max--;

                    }


                }

                //Present the final scores
                UI.PrintGameHeadline(trivia.Title);
                UI.PrintPlayersFinalScore(playersDB);
                confirmation = UI.WantContinueGame();

            } while (confirmation == false);

        }
    }
}