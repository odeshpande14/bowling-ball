using BowlingBall.Interfaces;
using BowlingBall.Constants;

namespace BowlingBall.Models
{
    public class RegularFrame : FrameBase
    {
        public RegularFrame(IFrameScoringStrategy scoreStrategy)
            : base(scoreStrategy) { }

        public RegularFrame(IFrameScoringStrategy scoreStrategy, List<int> rolls)
            : base(scoreStrategy)
        {
            this.rolls = rolls;
        }

        public override void AddRoll(int pins)
        {
            rolls.Add(pins);
        }

        public override bool IsFrameComplete()
        {
            return rolls.Count == Constants.Constants.MaxRollsPerFrame && rolls.Sum() < Constants.Constants.MaxPinsPerRoll;
        }
    }
}

