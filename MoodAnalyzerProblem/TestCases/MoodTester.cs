﻿namespace TestCases
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
        [TestMethod]
        public void GivenSad_ReturnSad()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer(); // Arrange

            string result = objMood.AnalyzeMood("I am in Sad Mood"); // Act

            Assert.AreEqual("Sad".ToUpper(), result); //Assert
        }
        [TestMethod]
        public void GivenAny_ReturnHappy()
        {
            MoodAnalyzerProblem.MoodAnalyzer objMood = new MoodAnalyzerProblem.MoodAnalyzer(); // Arrange

            string result = objMood.AnalyzeMood("I am in Any Mood"); // Act

            Assert.AreEqual("Happy".ToUpper(), result); //Assert
        }
    }
}