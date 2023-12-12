using BowlingBall.Interfaces;
using BowlingBall.Repositories;
using BowlingBall.Strategies;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            IScoreCalculationStrategy calculator = new StandardScoreCalculationStrategy();
            IFrameRepository frameRepository = new InMemoryFrameRepository();
            Game game = new(frameRepository,calculator);
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void AllStrike_Game_ShouldCalculateCorrectly()
        {
            IScoreCalculationStrategy calculator = new StandardScoreCalculationStrategy();
            IFrameRepository frameRepository = new InMemoryFrameRepository();
            Game game = new(frameRepository, calculator);
            Roll(game, 10, 21);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void AllSpare_Game_ShouldCalculateCorrectly()
        {
            IScoreCalculationStrategy calculator = new StandardScoreCalculationStrategy();
            IFrameRepository frameRepository = new InMemoryFrameRepository();
            Game game = new(frameRepository, calculator);
            Roll(game, 5, 21);
            Assert.AreEqual(150, game.GetScore());
        }

        private static void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
