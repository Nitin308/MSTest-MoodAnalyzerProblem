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
    }
}