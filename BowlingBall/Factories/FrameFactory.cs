using BowlingBall.Interfaces;
using BowlingBall.Models;
using BowlingBall.Strategies;

namespace BowlingBall.Factories
{
    public class FrameFactory : IFrameFactory
    {
        public IFrame CreateFrame(List<int> rolls, bool isTenthFrame = false)
        {
            if (isTenthFrame)
            {
                return new FinalFrame(new FinalFrameScoringStrategy(),rolls);
            }
            else if (rolls[0] == Constants.Constants.MaxPinsPerRoll)
                return new StrikeFrame(new StrikeFrameScoreStrategy(), rolls);
            else if (rolls.All(roll => roll == 5))
                return new FiveFiveFrame(new FiveFiveFrameScoreStrategy(), rolls);
            else if (rolls.Sum() == Constants.Constants.MaxPinsPerRoll)
                return new SpareFrame(new SpareFrameScoreStrategy(), rolls);
            else
                return new RegularFrame(new RegularFrameScoringStrategy(), rolls);
        }
    }

}

