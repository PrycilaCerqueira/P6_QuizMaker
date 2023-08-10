using System.Xml;
using System.IO;
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
            string username = Environment.UserName;
            string filePath = $@"C:\Users\{username}\Downloads\QuizCards.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, quizDB);
            }
        }

        public static List<Quiz> ImportFile()
        {

            string username = Environment.UserName;
            string filePath = $@"C:\Users\{username}\Downloads\QuizCards.xml";
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream reader = new FileStream(filePath, FileMode.Open))
            {
                var quizDB = (List<Quiz>)serializer.Deserialize(reader);
                return quizDB;
            }
            
        }
        


    }
}
