using BowlingBall.Interfaces;
using BowlingBall.Models;
using BowlingBall.Strategies;

namespace BowlingBall.Tests.FrameTests
{
    [TestClass]
    public class StrikeFrameFixture
	{
        [TestMethod]
        public void StrikeFrame_IsFrameComplete_AfterOneRoll()
        {
            IFrame frame = new StrikeFrame(new StrikeFrameScoreStrategy());
            frame.AddRoll(10);

            Assert.IsTrue(frame.IsFrameComplete());
        }

        [TestMethod]
        public void StrikeFrameScore_WithNextTwoRolls_ShouldIncludeThem()
        {
            IFrameScoringStrategy strategy = new StrikeFrameScoreStrategy();
            IFrame strikeFrame = new StrikeFrame(strategy);
            strikeFrame.AddRoll(10);

            IFrame nextFrame = new RegularFrame(new RegularFrameScoringStrategy());
            nextFrame.AddRoll(3);
            nextFrame.AddRoll(4);

            int score = strategy.CalculateScore(strikeFrame, new List<IFrame> { strikeFrame, nextFrame });
            Assert.AreEqual(17, score); 
        }
    }
}

