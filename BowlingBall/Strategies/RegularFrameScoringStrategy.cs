using BowlingBall.Interfaces;

namespace BowlingBall.Strategies
{
    public class RegularFrameScoringStrategy : IFrameScoringStrategy
    {
        public int CalculateScore(IFrame frame, List<IFrame> frames)
        {
            return frame.GetRolls().Sum();
        }
    }
}

