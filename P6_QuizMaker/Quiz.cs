using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6_QuizMaker
{
    internal class Quiz
    {     
        public string Question;
        public string Answer1;
        public string Answer2;
        public string Answer3;
        public string Answer4;
        public string CorrectAnswer;

        public static void AddQuestAnswersToList()
        {
            List<string> quizList = new List<string>();
            
            quizList.Add(Question);
            quizList.Add(Answer1);
            quizList.Add(Answer2);
            quizList.Add(Answer3);
            quizList.Add(Answer4);
            quizList.Add(CorrectAnswer);
        } 
    }
}
