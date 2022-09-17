using System;

namespace P6_QuizMaker // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game trivia = new Game();
            trivia.Title = "Tivia Quest";
            trivia.Description = "It is a game of questions and answers. Win who collects the highest score to the end.";
            UI.PrintGameInstructions(trivia.Title, trivia.Description);



        }
    }
}