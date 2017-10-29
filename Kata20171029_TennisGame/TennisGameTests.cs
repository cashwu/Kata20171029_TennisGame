using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Kata20171029_TennisGame
{
    [TestClass]
    public class TennisGameTests
    {
        private TennisGame tennisGame = new TennisGame();

        [TestMethod]
        public void Love_All()
        {
            AssertScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            tennisGame.FirstPlayerScore();
            AssertScoreShouldBe("Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Love()
        {
            tennisGame.FirstPlayerScore();
            tennisGame.FirstPlayerScore();
            AssertScoreShouldBe("Thirty Love");
        }

        private void AssertScoreShouldBe(string expected)
        {
            string score = tennisGame.Score();
            Assert.AreEqual(expected, score);
        }
    }

    public class TennisGame
    {
        private int firstPlayerScore;

        public string Score()
        {
            var scoreMapping = new Dictionary<int, string>()
            {
                { 1, "Fifteen"},
                { 2, "Thirty"},
            };
            if (firstPlayerScore != 0)
            {
                return scoreMapping[firstPlayerScore] + " Love";
            }
            return "Love All";
        }

        public void FirstPlayerScore()
        {
            firstPlayerScore++;
        }
    }
}