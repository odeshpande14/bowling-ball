using BowlingBall.Interfaces;
using BowlingBall.Models;
using BowlingBall.Strategies;

namespace BowlingBall.Tests.FrameTests
{
    [TestClass]
    public class RegularFrameFixture
	{

        [TestMethod]
        public void RegularFrame_Score_ShouldBeSumOfRolls()
        {
            IFrame frame = new RegularFrame(new RegularFrameScoringStrategy());
            frame.AddRoll(3);
            frame.AddRoll(4);

            Assert.AreEqual(7, frame.CalculateScore(new List<IFrame>()));
        }

        [TestMethod]
        public void RegularFrame_ScoreOfAllZeroRolls_ShouldBeZero()
        {
            IFrame frame = new RegularFrame(new RegularFrameScoringStrategy());
            frame.AddRoll(0);
            frame.AddRoll(0);

            Assert.AreEqual(0, frame.CalculateScore(new List<IFrame>()));
        }
    }
}

