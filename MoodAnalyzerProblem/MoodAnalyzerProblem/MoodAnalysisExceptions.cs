using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalysisExceptions : Exception
    {
        public MoodAnalysisExceptions()
        {

        }
        public MoodAnalysisExceptions(string message) : base(message)
        {

        }
    }
}