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

            //TODO: Fix the increment of the list
            /*
            var quizBank = new List<Quiz>()
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
                },
                new Quiz()
                {
                    Topic = UI.TopicInput(),
                    Question = UI.QuestionInput(),
                    Answer1 = UI.AnswersInput(),
                    Answer2 = UI.AnswersInput(),
                    Answer3 = UI.AnswersInput(),
                    Answer4 = UI.AnswersInput(),
                    CorrectAnswer = UI.RightAnswerInput()
                },
                new Quiz()
                {
                    Topic = UI.TopicInput(),
                    Question = UI.QuestionInput(),
                    Answer1 = UI.AnswersInput(),
                    Answer2 = UI.AnswersInput(),
                    Answer3 = UI.AnswersInput(),
                    Answer4 = UI.AnswersInput(),
                    CorrectAnswer = UI.RightAnswerInput()
                },

            };
            */

            var quizBank = new List<Quiz>(); //created a variable quizBank to be my LIST DB

            for (int numOfQuestions = 0; numOfQuestions < 2; numOfQuestions++) //Loop to add the which question&answers sub-list to main LIST DB
            {
                quizBank.Add(new Quiz // quizBank.add tells the system to add the new instance of Quiz (question&answers sub-list) to the LIST DB
                {
                    //Each list element will be input by the user
                    Topic = UI.TopicInput(), 
                    Question = UI.QuestionInput(),
                    Answer1 = UI.AnswersInput(),
                    Answer2 = UI.AnswersInput(),
                    Answer3 = UI.AnswersInput(),
                    Answer4 = UI.AnswersInput(),
                    CorrectAnswer = UI.RightAnswerInput()

                });
            }
            
            foreach (var quizItem in quizBank)
            {
                Console.WriteLine();
                Console.WriteLine(quizItem.Topic);

            }


         

        



        }
    }
}