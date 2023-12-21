using BowlingBall.Interfaces;
using BowlingBall.Models;
using BowlingBall.Strategies;

namespace BowlingBall.Tests.FrameTests
{
    [TestClass]
    public class FiveFiveFrameFixture
	{
        [TestMethod]
        public void FiveFiveFrameScore_WithHalfOfNextRoll_ShouldCalculateCorrectly()
        {
            IFrameScoringStrategy strategy = new FiveFiveFrameScoreStrategy();
            IFrame fiveFiveFrame = new FiveFiveFrame(strategy);
            fiveFiveFrame.AddRoll(5);
            fiveFiveFrame.AddRoll(5);
            // 5+5+4+2=16

            IFrame nextFrame = new RegularFrame(new RegularFrameScoringStrategy());
            nextFrame.AddRoll(4);
            nextFrame.AddRoll(4);

            int score = strategy.CalculateScore(fiveFiveFrame, new List<IFrame> { fiveFiveFrame, nextFrame });

            Assert.AreEqual(16, score); 
        }
    }
}

