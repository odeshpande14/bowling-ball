using BowlingBall.Interfaces;

namespace BowlingBall.Strategies
{
    public class StrikeFrameScoreStrategy : IFrameScoringStrategy
    {
        public int CalculateScore(IFrame frame, List<IFrame> frames)
        {
            int frameScore = frame.GetRolls().Sum();
            int bonusRollsCount = 0;

            var bonusRolls = frames.SkipWhile(f => f != frame)
                                   .Skip(1)
                                   .SelectMany(f => f.GetRolls())
                                   .TakeWhile(_ => bonusRollsCount++ < 2);

            return frameScore + bonusRolls.Sum();
        }
    }

}

