using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzer
    {
        string message = string.Empty;

        public MoodAnalyzer()
        {

        }

        public MoodAnalyzer(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood()
        {
            try
            {
                if (message == null)
                {
                    throw new MoodAnalysisExceptions(MoodAnalysisErrors.Null.ToString());
                }
                if (message == " ")
                {
                    throw new MoodAnalysisExceptions(MoodAnalysisErrors.Empty.ToString());
                }
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
                return "HAPPY";
            }
            catch (MoodAnalysisExceptions ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return "HAPPY";
            }
        }
    }
    public enum MoodAnalysisErrors
    {
        Null,
        Empty
    }
}