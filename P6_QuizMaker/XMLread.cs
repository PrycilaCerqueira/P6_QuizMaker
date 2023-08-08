using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace P6_QuizMaker
{

    internal class XMLread
    {
        [XmlRoot(ElementName = "Answers")]
        public class Answers
        {

            [XmlElement(ElementName = "string")]
            public List<string> String { get; set; }
        }

        [XmlRoot(ElementName = "Quiz")]
        public class Quiz
        {

            [XmlElement(ElementName = "Topic")]
            public string Topic { get; set; }

            [XmlElement(ElementName = "Question")]
            public string Question { get; set; }

            [XmlElement(ElementName = "Answers")]
            public Answers Answers { get; set; }
        }

        [XmlRoot(ElementName = "ArrayOfQuiz")]
        public class ArrayOfQuiz
        {

            [XmlElement(ElementName = "Quiz")]
            public List<Quiz> Quiz { get; set; }

            [XmlAttribute(AttributeName = "xsi")]
            public string Xsi { get; set; }

            [XmlAttribute(AttributeName = "xsd")]
            public string Xsd { get; set; }

            [XmlText]
            public string Text { get; set; }
        }



    }
}
