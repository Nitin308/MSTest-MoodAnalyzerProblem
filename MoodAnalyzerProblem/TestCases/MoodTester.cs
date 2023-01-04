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
    }
}