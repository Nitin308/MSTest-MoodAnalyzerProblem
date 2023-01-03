namespace MoodAnalyzerProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyzer Program");
        }
    }

    public class MoodAnalyzer
    {
        public string AnalyzeMood(string message)
        {
            var mood1 = message.Contains("Happy", StringComparison.OrdinalIgnoreCase);
            if (mood1)
            {
                return "HAPPY";
            }
            var mood2 = message.Contains("Sad", StringComparison.OrdinalIgnoreCase);
            if (mood2)
            {
                return "SAD";
            }
            return String.Empty;
        }
    }
}