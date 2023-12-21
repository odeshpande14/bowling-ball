using BowlingBall.Interfaces;

namespace BowlingBall.Strategies
{
    public class FinalFrameScoringStrategy : IFrameScoringStrategy
    {
        public int CalculateScore(IFrame frame, List<IFrame> frames)
        {
            return frame.GetRolls().Sum();
        }
    }
}

