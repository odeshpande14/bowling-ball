using BowlingBall.Interfaces;
using BowlingBall.Managers;

namespace BowlingBall
{
    public class Game
    {
        private readonly FrameManager frameManager;

        public Game(IFrameRepository frameRepository, IFrameFactory frameFactory)
        {
            frameManager = new FrameManager(frameRepository, frameFactory);
        }

        public void Roll(int pins)
        {
            if (frameManager.IsGameComplete())
            {
                throw new Exception("Game is already complete.");
            }

            frameManager.AddRoll(pins);
        }

        public int GetScore()
        {
            return frameManager.CalculateScore();
        }
    }

}
