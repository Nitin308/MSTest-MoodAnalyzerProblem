namespace TestCases
{
    [TestClass]
    public class MoodTester
    {
        [TestMethod]
        public void TestHappyOrSad()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer(); // Arrange

            string result = objMood.AnalyzeMood("Happy"); // Act

            Assert.AreEqual("Happy".ToUpper(), result); //Assert
        }
    }
}