using BowlingBall.Factories;
using BowlingBall.Interfaces;
using BowlingBall.Models;

namespace BowlingBall.Tests
{
    [TestClass]
    public class FrameFactoryFixture
	{
        [TestMethod]
        public void FrameFactory_ShouldCreateRegularFrame_ForRegularRolls()
        {
            FrameFactory frameFactory = new();
            List<int> rolls = new() { 3, 4 };
            IFrame frame = frameFactory.CreateFrame(rolls);

            Assert.IsInstanceOfType(frame, typeof(RegularFrame));
        }

        [TestMethod]
        public void FrameFactory_ShouldCreateSpareFrame_ForSpareRolls()
        {
            List<int> rolls = new() { 6, 4 };
            FrameFactory frameFactory = new();
            IFrame frame = frameFactory.CreateFrame(rolls);

            Assert.IsInstanceOfType(frame, typeof(SpareFrame));
        }

        [TestMethod]
        public void FrameFactory_ShouldCreateStrikeFrame_ForStrikeRoll()
        {
            List<int> rolls = new() { 10 };
            FrameFactory frameFactory = new();
            IFrame frame = frameFactory.CreateFrame(rolls);

            Assert.IsInstanceOfType(frame, typeof(StrikeFrame));
        }

        [TestMethod]
        public void FrameFactory_ShouldCreateFiveFiveFrame_ForFiveFiveRolls()
        {
            List<int> rolls = new() { 5, 5 };
            FrameFactory frameFactory = new();
            IFrame frame = frameFactory.CreateFrame(rolls);

            Assert.IsInstanceOfType(frame, typeof(FiveFiveFrame));
        }


        [TestMethod]
        public void FrameFactory_ShouldCreateFinalFrame_ForFinalFrame()
        {
            List<int> rolls = new() { 5, 5 };
            FrameFactory frameFactory = new();
            IFrame frame = frameFactory.CreateFrame(rolls,true);

            Assert.IsInstanceOfType(frame, typeof(FinalFrame));
        }
    }
}

