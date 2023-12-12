
using BowlingBall.Enums;
using BowlingBall.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class FrameTests
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
    }
}
