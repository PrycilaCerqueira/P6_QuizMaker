using System;

namespace P6_QuizMaker // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game trivia = new Game();
            trivia.Title = "Tivia Quest";
            trivia.Description = "It is a game of questions and answers. Win who collects the highest score to the end.\nIn this Trivia Quest version, you will initially create your bank of questions.";
            UI.PrintGameInstructions(trivia.Title, trivia.Description);

            Player inGameID = new Player();
            inGameID.Name = UI.PrintPlayerInfo(inGameID.score);

            var quizBank = new List<Quiz>();
            
            //TODO: Fix the increment of the list
            int questionCount = 0;         
            while (questionCount < 3)
            {
                new Quiz()
                {
                        Topic = UI.TopicInput(),
                        Question = UI.QuestionInput(),
                        Answer1 = UI.AnswersInput(),
                        Answer2 = UI.AnswersInput(),
                        Answer3 = UI.AnswersInput(),
                        Answer4 = UI.AnswersInput(),
                        CorrectAnswer = UI.RightAnswerInput()
                };
                questionCount++;
            }                

        



        }
    }
}