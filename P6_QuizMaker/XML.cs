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
        public static void ExportFile(List<Quiz> quizDB, string filePath)
        {
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, quizDB);
            }
        }

        public static List<Quiz> ImportFile(string filePath)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(List<Quiz>));
            using (FileStream reader = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                    var quizDB = (List<Quiz>)serializer.Deserialize(reader);
                    return quizDB;
            }
        
            
        }

        public static bool dbFileExist(string filePath)
        {
            
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Quiz> LoadDB()
        {
            List<Quiz> quizDB;

            string username = Environment.UserName;
            string filePath = $@"C:\Users\{username}\Downloads\QuizCards.xml";

            if (dbFileExist(filePath) == true)
            {
                quizDB = ImportFile(filePath);
                quizDB.AddRange(UI.GetQuizCards());
                ExportFile(quizDB, filePath);
            }
            else
            {
                quizDB = UI.GetQuizCards();
                ExportFile(quizDB, filePath);
            }
            return quizDB;
        }




    }
}
