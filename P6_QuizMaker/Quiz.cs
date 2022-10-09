using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P6_QuizMaker
{
    internal class Quiz
    {
        public string Topic { get; set; }
        public string Question {get; set;}     
        public List<string> QuizAnswers { get; set; } = new List<string>();

    }


}
