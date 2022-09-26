using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P6_QuizMaker
{
    internal class Quizzes : IEquatable<Quizzes>
    {
        public string Topic { get; set; }
        public string Question {get; set;}
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string CorrectAnswer { get; set; }

        public bool Equals(Quizzes other)
        {
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return Topic.Equals(other.Topic);
        }


    }
}
