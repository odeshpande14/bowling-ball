using BowlingBall.Interfaces;

namespace BowlingBall.Models
{
    public class FiveFiveFrame : FrameBase
    {
        public FiveFiveFrame(IFrameScoringStrategy scoreStrategy)
            : base(scoreStrategy) { }

        public FiveFiveFrame(IFrameScoringStrategy scoreStrategy, List<int> rolls)
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
            return rolls.Count == Constants.Constants.MaxRollsPerFrame && rolls.All(pins => pins == 5);
        }
    }

}

