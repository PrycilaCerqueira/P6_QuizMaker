using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;


namespace P6_QuizMaker
{
    internal class XML
    {
        /// <summary>
        /// Converts the QuizCards into a plain text and exports the data locally
        /// </summary>
        /// <param name="quizDB"></param>
        public static void ExportFile(List<Quiz> quizDB)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
            string username = Environment.UserName;
            using (StreamWriter writer = new StreamWriter($@"C:\Users\{username}\Downloads\QuizCards.xml"))
            {
                serializer.Serialize(writer, quizDB);
            }
        }

        public static List<Quiz> ImportFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XMLread.ArrayOfQuiz[]));
            string username = Environment.UserName;
            using (StringReader reader = new StringReader($@"C:\Users\{username}\Downloads\QuizCards.xml"))
            {
                var quizDB = (XMLread.ArrayOfQuiz[])serializer.Deserialize(reader);
                return quizDB;
            }
        }
        

    }
}
