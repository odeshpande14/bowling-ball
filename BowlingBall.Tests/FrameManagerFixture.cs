using BowlingBall.Factories;
using BowlingBall.Managers;
using BowlingBall.Repositories;

namespace BowlingBall.Tests
{
    [TestClass]
    public class FrameManagerFixture
	{
        [TestMethod]
        public void FrameManager_ShouldCreateNewFrame_AfterCompleteFrame()
        {
            var frameRepository = new InMemoryFrameRepository();
            var frameFactory = new FrameFactory();
            var frameManager = new FrameManager(frameRepository, frameFactory);
            frameManager.AddRoll(5);
            frameManager.AddRoll(4); 

            frameManager.AddRoll(7);

            Assert.AreEqual(1, frameRepository.GetAllFrames().Count);
            frameManager.AddRoll(1);
            Assert.AreEqual(2, frameRepository.GetAllFrames().Count);

        }

        [TestMethod]
        public void FrameManager_ShouldCalculateScore_Correctly()
        {
            var frameRepository = new InMemoryFrameRepository();
            var frameFactory = new FrameFactory();
            var frameManager = new FrameManager(frameRepository, frameFactory);
            frameManager.AddRoll(5);
            frameManager.AddRoll(5); 
            frameManager.AddRoll(3);
            frameManager.AddRoll(3);
            frameManager.AddRoll(0);

            int score = frameManager.CalculateScore();

            Assert.AreEqual(20, score); 
        }
    }
}

