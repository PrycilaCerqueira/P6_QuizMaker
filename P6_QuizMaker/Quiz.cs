namespace P6_QuizMaker
{
    [Serializable]
    public class Quiz
    {
        public string Topic { get; set; }
        public string Question {get; set;}     
        public List<string> Answers { get; set; } = new List<string>();

    }


}
