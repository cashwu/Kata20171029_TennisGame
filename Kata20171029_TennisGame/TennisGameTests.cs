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
            FirstPlayerScoreTime(2);
            AssertScoreShouldBe("Thirty Love");
        }

        [TestMethod]
        public void Forty_Love()
        {
            FirstPlayerScoreTime(3);
            AssertScoreShouldBe("Forty Love");
        }

        private void FirstPlayerScoreTime(int time)
        {
            for (int i = 0; i < time; i++)
            {
                tennisGame.FirstPlayerScore();
            }
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
                { 3, "Forty"},
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