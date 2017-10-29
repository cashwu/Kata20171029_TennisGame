using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            if (firstPlayerScore != 0)
            {
                return "Fifteen Love";
            }
            return "Love All";
        }

        public void FirstPlayerScore()
        {
            firstPlayerScore++;
        }
    }
}