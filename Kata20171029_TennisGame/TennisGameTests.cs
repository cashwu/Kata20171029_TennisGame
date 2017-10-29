using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Kata20171029_TennisGame
{
    [TestClass]
    public class TennisGameTests
    {
        private TennisGame tennisGame = new TennisGame("Player1", "Player2");

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
            SecondPlayerScoreTime(2);
            AssertScoreShouldBe("Love Thirty");
        }

        [TestMethod]
        public void Fifteen_All()
        {
            FirstPlayerScoreTime(1);
            SecondPlayerScoreTime(1);
            AssertScoreShouldBe("Fifteen All");
        }

        [TestMethod]
        public void Deuce()
        {
            FirstPlayerScoreTime(3);
            SecondPlayerScoreTime(3);
            AssertScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void Deuce_when_4()
        {
            FirstPlayerScoreTime(4);
            SecondPlayerScoreTime(4);
            AssertScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void FirstPlayer_Adv()
        {
            FirstPlayerScoreTime(5);
            SecondPlayerScoreTime(4);
            AssertScoreShouldBe("Player1 Adv");
        }

        private void SecondPlayerScoreTime(int time)
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
        private readonly string player1;
        private readonly string player2;
        private int firstPlayerScore;
        private int secondPlayerScore;

        private Dictionary<int, string> scoreMapping = new Dictionary<int, string>()
            {
                { 0, "Love"},
                { 1, "Fifteen"},
                { 2, "Thirty"},
                { 3, "Forty"},
            };

        public TennisGame(string player1, string player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public string Score()
        {
            if (firstPlayerScore != secondPlayerScore)
            {
                if (firstPlayerScore > 3)
                {
                    return player1 + " Adv";
                }
                return scoreMapping[firstPlayerScore] + " " + scoreMapping[secondPlayerScore];
            }
            if (firstPlayerScore >= 3)
            {
                return "Deuce";
            }
            return scoreMapping[secondPlayerScore] + " All";
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