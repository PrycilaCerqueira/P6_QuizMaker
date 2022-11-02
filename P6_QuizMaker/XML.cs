using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace P6_QuizMaker
{
    internal class XML
    {
        public static void ExportFile(List<Quiz> quizDB)
        {
            var serializer = new XmlSerializer(typeof(List<Quiz>));
            using (var writer = new StreamWriter(@"C:\Users\pry_p\source\repos\P6_QuizMaker\QuizCards.xml"))
            {
                serializer.Serialize(writer, quizDB);
            }
        }
    }
}
