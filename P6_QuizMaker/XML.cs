using System.Xml.Serialization;


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
            using (StreamWriter writer = new StreamWriter(@"C:\Users\pry_p\source\repos\P6_QuizMaker\QuizCards.xml"))
            {
                serializer.Serialize(writer, quizDB);
            }
        }
    }
}
