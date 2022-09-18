using System;

namespace P6_QuizMaker // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game trivia = new Game();
            trivia.Title = "Tivia Quest";
            trivia.Description = "It is a game of questions and answers. Win who collects the highest score to the end.\nIn this Trivia Quest version, you will initially create your bank of question.";
            UI.PrintGameInstructions(trivia.Title, trivia.Description);

            Player inGameID = new Player();
            inGameID.Name = UI.PrintPlayerInfo(inGameID.score);

            Quiz HarryPotter = new Quiz();
            List<string> quizList = new List<string>();
            quizList.Add(HarryPotter.Question = UI.QuestionInput());
            //quizList.Add(HarryPotter.Answer1);
            //quizList.Add(HarryPotter.Answer2);
            //quizList.Add(HarryPotter.Answer3);
            //quizList.Add(HarryPotter.Answer4);
            //quizList.Add(HarryPotter.CorrectAnswer);


        }
    }
}