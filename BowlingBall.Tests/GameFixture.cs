using System.Net.NetworkInformation;
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
        public void Random_Game_ShouldCalculateCorrectly()
        {
            IScoreCalculationStrategy calculator = new StandardScoreCalculationStrategy();
            IFrameRepository frameRepository = new InMemoryFrameRepository();
            Game game = new(frameRepository, calculator);
            game.Roll(2);
            game.Roll(7);
            // 2+7 = 9
            game.Roll(8);
            game.Roll(2);
            // 9+ 8+2 +3(B) = 22
            game.Roll(3);
            game.Roll(4);
            // 22+ 3+4 = 29
            game.Roll(6);
            game.Roll(4);
            // 29+ 6+4 +10(B) = 49
            game.Roll(10);
            // 49+ 10 +19(B) = 68
            game.Roll(9);
            game.Roll(0);
            // 68+ 9+0 = 77
            game.Roll(6);
            game.Roll(3);
            // 77+ 6+3 = 86
            game.Roll(4);
            game.Roll(5);
            // 86+ 4+5 = 95
            game.Roll(5);
            game.Roll(4);
            // 95+ 5+4 = 104
            game.Roll(10);
            game.Roll(2);
            game.Roll(3);
            // 104+ 10+2+3 = 119
            Assert.AreEqual(119, game.GetScore());
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
