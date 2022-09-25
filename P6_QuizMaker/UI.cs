namespace P6_QuizMaker
{
    internal class UI
    {
        /// <summary>
        /// Prints the art game title 
        /// </summary>
        /// <param name="gameTitle">Name of the game</param>
        public static void PrintGameHeadline(string gameTitle)
        {
            //Console.WriteLine($"Welcome to {gameTitle}");
            Console.WriteLine
                (@"
                      ______     _       _          ____                  __ 
                     /_  __/____(_)   __(_)___ _   / __ \__  _____  _____/ /_
                      / / / ___/ / | / / / __ `/  / / / / / / / _ \/ ___/ __/
                     / / / /  / /| |/ / / /_/ /  / /_/ / /_/ /  __(__  ) /_  
                    /_/ /_/  /_/ |___/_/\__,_/   \___\_\__,_/\___/____/\__/  

                ");

        }
        
        
        /// <summary>
        /// Prints the game description on the console for the players
        /// </summary>
        /// <param name="gameDescription">Description of the game</param>
        public static void PrintGameInstructions(string gameDescription)
        {
            Console.WriteLine(gameDescription);
            Console.WriteLine(); //skips a line
        }

        /// <summary>
        /// Prints the player chosen name and their initial score
        /// </summary>
        /// <param name="score">By default the initial score is zero</param>
        /// <returns>The player chosen name</returns>
        public static string PrintPlayerInfo(int score)
        {
            string inGameID;

            Console.Write("Create your in-game ID: ");
            inGameID = InputVerification();

            Console.WriteLine($"Welcome {inGameID}! Your initial score is {score}.");

            return inGameID;
        }



        //QUIZ INPUT BLOCK

        /// <summary>
        /// Allows the player to enter their question topic
        /// </summary>
        /// <returns>The topic</returns>
        public static string TopicInput()
        {
            string topic;
            Console.WriteLine(); //skips a line
            Console.Write("Enter the question topic: ");
            topic = InputVerification();
            return topic;
        }
        
        /// <summary>
        /// Allows the player to enter their question
        /// </summary>
        /// <returns>The question</returns>
        public static string QuestionInput()
        {
            string question;
            Console.Write("Enter your question: ");
            question = InputVerification();
            return question;
        }

        /// <summary>
        /// Allows the player to enter their answer for the question
        /// </summary>
        /// <returns>The answer</returns>
        public static string AnswersInput()
        {
            string answer;
            Console.Write("Enter your answer: ");
            answer = InputVerification();
            return answer;
        }


        /// <summary>
        /// Allows the player to enter their correct answer for the question
        /// </summary>
        /// <returns>The correct answer</returns>
        public static string RightAnswerInput()
        {
            string answer;
            Console.Write("Enter right answer to your question: ");
            answer = InputVerification();
            return answer;
        }

        /// <summary>
        /// Verifies whether or not the input complies with the program minimum requirements 
        /// </summary>
        /// <returns>The compliant input string</returns>
        static string InputVerification()
        {
            string txtInput;

            while (true)
            {
                txtInput = Console.ReadLine().ToUpper().Trim();

                if (String.IsNullOrWhiteSpace(txtInput))
                {
                    Console.WriteLine("Empty or Spaces are invalid entries.");
                    Console.Write("Try again: ");
                    continue;
                }
                if (txtInput.Length > 100)
                {
                    Console.WriteLine("The text length cannot be longer than 100 characters.");
                    Console.Write("Try again: ");
                    continue;
                }
                break;
            }
            return txtInput;
        }

        /// <summary>
        /// Confirms whether the player would like to continue the game or not
        /// </summary>
        public static void wantContinueGame()
        {
            string continueYesNo;
            Console.WriteLine("\nWould you like to continue? (Y/N)");

            if(Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.Clear();
            }
            else 
            {
                Environment.Exit(0);   
            }
         
        }
    }
}
