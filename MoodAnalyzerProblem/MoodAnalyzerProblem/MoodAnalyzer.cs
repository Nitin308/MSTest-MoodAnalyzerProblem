using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzer
    {
        //string message = string.Empty;
        public string message { get; set; }

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
        Empty,
        NO_SUCH_CLASS,
        NO_SUCH_METHOD
    }

    public class MoodAnalyzerFactory
    {

        public static object CreateInstance(string className, [Optional] string constructorName)
        {
            try
            {
                Type type = Type.GetType(className);
                if (type == null)
                {
                    throw new MoodAnalysisExceptions(MoodAnalysisErrors.NO_SUCH_CLASS.ToString());
                }
                else if (constructorName != null)
                {
                    bool exists = false;
                    var constructors = type.GetConstructors();
                    foreach (var constructor in constructors)
                    {
                        if (constructor.ToString() == constructorName)
                        {
                            exists = true;
                            continue;
                        }
                    }
                    if (!exists)
                    {
                        throw new MoodAnalysisExceptions(MoodAnalysisErrors.NO_SUCH_METHOD.ToString());
                    }
                }
                return type;
            }
            catch (MoodAnalysisExceptions ex)
            {
                return ex.Message;
            }
        }
    }
}