using BowlingBall.Interfaces;

namespace BowlingBall.Strategies
{
    public class SpareFrameScoreStrategy : IFrameScoringStrategy
    {
        public int CalculateScore(IFrame frame, List<IFrame> frames)
        {
            int frameScore = frame.GetRolls().Sum();
            var nextFrame = frames.SkipWhile(f => f != frame).Skip(1).FirstOrDefault();
            int bonus = nextFrame?.GetRolls().FirstOrDefault() ?? 0;

            return frameScore + bonus;
        }
    }


}

