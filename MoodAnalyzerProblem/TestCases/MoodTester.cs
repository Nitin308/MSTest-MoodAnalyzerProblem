using MoodAnalyzerProblem;

namespace TestCases
{
    [TestClass]
    public class MoodTester
    {
        [TestMethod]
        public void TestHappyOrSad()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer("Happy"); // Arrange

            string result = objMood.AnalyzeMood(); // Act

            Assert.AreEqual("Happy".ToUpper(), result); //Assert
        }

        [TestMethod]
        public void GivenSad_ReturnSad()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer("I am in Sad Mood"); // Arrange

            string result = objMood.AnalyzeMood(); // Act

            Assert.AreEqual("Sad".ToUpper(), result); //Assert
        }

        [TestMethod]
        public void GivenAny_ReturnHappy()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer("I am in Any Mood"); // Arrange

            string result = objMood.AnalyzeMood(); // Act

            Assert.AreEqual("Happy".ToUpper(), result); //Assert
        }

        [TestMethod]
        public void GivenNull_ReturnHappy()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer(null); // Arrange

            string result = objMood.AnalyzeMood(); // Act

            Assert.AreEqual("Happy".ToUpper(), result); //Assert
        }

        [TestMethod]
        public void CustomExceptions_GivenNull_ThrowNull()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer(null); // Arrange

            string result = objMood.AnalyzeMood(); // Act

            Assert.AreEqual(MoodAnalysisErrors.Null.ToString(), result); //Assert
        }

        [TestMethod]
        public void CustomExceptions_GivenEmpty_ThrowEmpty()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer(" "); // Arrange

            string result = objMood.AnalyzeMood(); // Act

            Assert.AreEqual(MoodAnalysisErrors.Empty.ToString(), result); //Assert
        }

        [TestMethod]
        public void CreateMoodAnalyzerObject_DefaultConstructor_UsingReflection()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer();

            var objFactory = MoodAnalyzerFactory.CreateInstance("MoodAnalyzerProblem.MoodAnalyzer");

            Assert.IsInstanceOfType(objMood, (Type)objFactory);
        }

        [TestMethod]
        public void CreateMoodAnalyzerObject_DefaultConstructor_UsingReflection_GivenImproperClass_ReturnNoSuchClass()
        {
            //MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer();

            var objFactory = (string)MoodAnalyzerFactory.CreateInstance("MoodAnalyzerProb.MoodAnalyzer");

            Assert.AreEqual(MoodAnalysisErrors.NO_SUCH_CLASS.ToString(), objFactory);
        }

        [TestMethod]
        public void CreateMoodAnalyzerObject_DefaultConstructor_UsingReflectionException_GivenImproperConstructor_ReturnNoSuchMethod()
        {
            //MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer();

            var objFactory = (string)MoodAnalyzerFactory.CreateInstance("MoodAnalyzerProblem.MoodAnalyzer", "MoodAnalyzerFactor");

            Assert.AreEqual(MoodAnalysisErrors.NO_SUCH_METHOD.ToString(), objFactory);
        }
    }
}