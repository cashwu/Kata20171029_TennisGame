using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod]
        public void SecondPlayer_Adv()
        {
            FirstPlayerScoreTime(4);
            SecondPlayerScoreTime(5);
            AssertScoreShouldBe("Player2 Adv");
        }

        [TestMethod]
        public void FirstPlayer_Win()
        {
            FirstPlayerScoreTime(4);
            SecondPlayerScoreTime(0);
            AssertScoreShouldBe("Player1 Win");
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
            return IsScoreDiff()
                ? (firstPlayerScore > 3 ? AdvState() : NormalScore())
                : (IsDeuce() ? Deuce() : SameScore());
        }

        private string SameScore()
        {
            return scoreMapping[secondPlayerScore] + " All";
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private bool IsDeuce()
        {
            return firstPlayerScore >= 3;
        }

        private bool IsScoreDiff()
        {
            return firstPlayerScore != secondPlayerScore;
        }

        private string AdvState()
        {
            return AdvPlayer() + (IsAdv() ? " Adv" : " Win");
        }

        private string NormalScore()
        {
            return scoreMapping[firstPlayerScore] + " " + scoreMapping[secondPlayerScore];
        }

        private bool IsAdv()
        {
            return Math.Abs(firstPlayerScore - secondPlayerScore) == 1;
        }

        private string AdvPlayer()
        {
            var advPlayer = firstPlayerScore > secondPlayerScore
                ? player1
                : player2;
            return advPlayer;
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