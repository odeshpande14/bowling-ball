using BowlingBall.Models;
using BowlingBall.Services;

namespace BowlingBall.Tests
{
    [TestClass]
    public class ScoreCalculatorFixture
    {
        [TestMethod]
        public void CalculateScore_WithNormalFrames_ShouldReturnCorrectTotalScore()
        {
            var frames = new List<Frame>
            {
                new Frame(1, 2),
                new Frame(1, 2),
                new Frame(1, 2),
                new Frame(1, 2),
                new Frame(1, 2),
                new Frame(1, 2),
                new Frame(1, 2),
                new Frame(1, 2),
                new Frame(1, 2),
                new Frame(1, 2),
            };
            var calculator = new ScoreCalculator();
            int score = calculator.CalculateScore(frames);
            Assert.AreEqual(30, score);
        }
    }
}

