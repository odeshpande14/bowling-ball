using BowlingBall.Interfaces;

namespace BowlingBall.Models
{
    public class StrikeFrame : FrameBase
    {
        public StrikeFrame(IFrameScoringStrategy scoreStrategy)
            : base(scoreStrategy) { }

        public StrikeFrame(IFrameScoringStrategy scoreStrategy, List<int> rolls)
            : base(scoreStrategy)
        {
            this.rolls = rolls;
        }

        public override void AddRoll(int pins)
        {
            if (rolls.Count == 0)
                rolls.Add(pins);
        }

        public override bool IsFrameComplete()
        {
            return rolls.Count == 1;
        }
    }

}

