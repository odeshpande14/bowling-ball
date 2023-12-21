using BowlingBall.Interfaces;

namespace BowlingBall.Strategies
{
    public class FiveFiveFrameScoreStrategy : IFrameScoringStrategy
    {
        public int CalculateScore(IFrame frame, List<IFrame> frames)
        {
            int frameScore = frame.GetRolls().Sum();
            var nextFrame = frames.SkipWhile(f => f != frame).Skip(1).FirstOrDefault();

            int spareBonus = nextFrame != null ? nextFrame.GetRolls().FirstOrDefault() : 0;
            int fiveFiveBonus =  spareBonus / 2;

            return frameScore + spareBonus + fiveFiveBonus;
        }
    }

}

