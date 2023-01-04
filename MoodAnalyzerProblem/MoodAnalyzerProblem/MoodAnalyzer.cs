using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerProblem
{
    public class MoodAnalyzer
    {
        //string message = string.Empty;
        public string message;

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
        NO_SUCH_METHOD,
        NO_SUCH_CONSTRUCTOR
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

        public static object CreateInstanceParameterConstructor(string className, string constructorName, string message)
        {
            Type type = Type.GetType(className);
            try
            {
                if (type == null)
                {
                    throw new MoodAnalysisExceptions(MoodAnalysisErrors.NO_SUCH_CLASS.ToString());
                }
                if (type.Name != constructorName)
                {
                    throw new MoodAnalysisExceptions(MoodAnalysisErrors.NO_SUCH_CONSTRUCTOR.ToString());
                }
                ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
                object instance = ctor.Invoke(new object[] { message });
                return instance;
            }
            catch (MoodAnalysisExceptions ex)
            {
                return ex.Message;
            }
        }

        public static string InvokeMethod(string methodName, string message)
        {
            MoodAnalyzerFactory objFactory = new MoodAnalyzerFactory();
            Type type = typeof(MoodAnalyzer);
            try
            {
                if (type.Name != methodName)
                {
                    throw new MoodAnalysisExceptions(MoodAnalysisErrors.NO_SUCH_METHOD.ToString());
                }
                else
                {
                    object methodObject = MoodAnalyzerFactory.CreateInstanceParameterConstructor("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzer", message);
                    MethodInfo methodInfo = type.GetMethod(methodName);
                    string method = (string)methodInfo.Invoke(methodObject, null);
                    return method;
                }
            }
            catch (MoodAnalysisExceptions ex)
            {
                return ex.Message;
            }

        }
    }
}