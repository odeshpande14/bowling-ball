using BowlingBall.Interfaces;
using BowlingBall.Models;
using BowlingBall.Strategies;

namespace BowlingBall.Tests.FrameTests
{
    [TestClass]
    public class SpareFrameFixture
	{

        [TestMethod]
        public void SpareFrameScore_WithNextRoll_ShouldIncludeNextRoll()
        {
            IFrameScoringStrategy strategy = new SpareFrameScoreStrategy();
            IFrame spareFrame = new SpareFrame(strategy);
            spareFrame.AddRoll(4);
            spareFrame.AddRoll(6);

            IFrame nextFrame = new RegularFrame(new RegularFrameScoringStrategy());
            nextFrame.AddRoll(3);

            int score = strategy.CalculateScore(spareFrame, new List<IFrame> { spareFrame, nextFrame });
            Assert.AreEqual(13, score); 
        }

    }
}

