using System.Net.NetworkInformation;
using BowlingBall.Factories;
using BowlingBall.Interfaces;
using BowlingBall.Repositories;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            IFrameRepository frameRepository = new InMemoryFrameRepository();
            IFrameFactory frameFactory = new FrameFactory();
            Game game = new(frameRepository, frameFactory);
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void AllStrike_Game_ShouldCalculateCorrectly()
        {
            IFrameRepository frameRepository = new InMemoryFrameRepository();
            IFrameFactory frameFactory = new FrameFactory();
            Game game = new(frameRepository, frameFactory);
            Roll(game, 10, 12);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void Random_Game_ShouldCalculateCorrectly()
        {
            IFrameRepository frameRepository = new InMemoryFrameRepository();
            IFrameFactory frameFactory = new FrameFactory();
            Game game = new Game(frameRepository, frameFactory);
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
            IFrameRepository frameRepository = new InMemoryFrameRepository();
            IFrameFactory frameFactory = new FrameFactory();
            Game game = new Game(frameRepository, frameFactory);
            game.Roll(4);
            game.Roll(6);
            // 4+6+4=14
            game.Roll(4);
            game.Roll(6);
            // 14+4+6+14 = 28
            game.Roll(4);
            game.Roll(6);
            // 42
            game.Roll(4);
            game.Roll(6);
            // 56
            game.Roll(4);
            game.Roll(6);
            // 70
            game.Roll(4);
            game.Roll(6);
            // 84
            game.Roll(4);
            game.Roll(6);
            // 98
            game.Roll(4);
            game.Roll(6);
            // 112
            game.Roll(4);
            game.Roll(6);
            // 126
            game.Roll(4);
            game.Roll(6);
            game.Roll(4);
            //140

            Assert.AreEqual(140, game.GetScore());
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
