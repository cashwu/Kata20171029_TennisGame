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

        [TestMethod]
        public void Love_Fifteen()
        {
            tennisGame.SecondPlayerScore();
            AssertScoreShouldBe("Love Fifteen");
        }

        [TestMethod]
        public void Love_Thirty()
        {
            SecondScoreTime(2);
            AssertScoreShouldBe("Love Thirty");
        }

        private void SecondScoreTime(int time)
        {
            for (int i = 0; i < time; i++)
            {
                tennisGame.SecondPlayerScore();
            }
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
        private int secondPlayerScore;

        public string Score()
        {
            var scoreMapping = new Dictionary<int, string>()
            {
                { 0, "Love"},
                { 1, "Fifteen"},
                { 2, "Thirty"},
                { 3, "Forty"},
            };
            if (firstPlayerScore != 0 || secondPlayerScore != 0)
            {
                return scoreMapping[firstPlayerScore] + " " + scoreMapping[secondPlayerScore];
            }
            return "Love All";
        }

        public void FirstPlayerScore()
        {
            firstPlayerScore++;
        }

        public void SecondPlayerScore()
        {
            secondPlayerScore++;
        }
    }
}