
using BowlingBall.Enums;
using BowlingBall.Models;

namespace BowlingBall.Tests
{
    [TestClass]
    public class FrameFixture
    {
        [TestMethod]
        public void Frame_Initialization_ShouldSetPropertiesCorrectly()
        {
            int firstRoll = 5;
            int secondRoll = 4;

            var frame = new Frame(firstRoll, secondRoll);

            Assert.AreEqual(firstRoll, frame.FirstRoll);
            Assert.AreEqual(secondRoll, frame.SecondRoll);
            Assert.AreEqual(FrameType.Normal, frame.Type);
        }

        [TestMethod]
        public void Frame_WithStrike_ShouldSetTypeAsStrike()
        {
            int firstRoll = 10;
            var frame = new Frame(firstRoll, 0);
            Assert.AreEqual(FrameType.Strike, frame.Type);
        }

        [TestMethod]
        public void Frame_WithSpare_ShouldSetTypeAsSpare()
        {
            int firstRoll = 8;
            int secondRoll = 2;
            var frame = new Frame(firstRoll, secondRoll);
            Assert.AreEqual(FrameType.Spare, frame.Type);
        }
    }
}
