using BowlingBall.Interfaces;

namespace BowlingBall.Models
{
    public class FinalFrame : FrameBase
    {
        public FinalFrame(IFrameScoringStrategy scoreStrategy)
            : base(scoreStrategy) { }

        public FinalFrame(IFrameScoringStrategy scoreStrategy, List<int> rolls)
            : base(scoreStrategy)
        {
            this.rolls = rolls;
        }

        public override void AddRoll(int pins)
        {
            if (rolls.Count < Constants.Constants.MaxRollsPerFrame+Constants.Constants.BonusRollsForFinalFrame)
            {
                rolls.Add(pins);
            }
        }

        public override bool IsFrameComplete()
        {
            if (rolls[0] == Constants.Constants.MaxPinsPerRoll)
            {
                return rolls.Count == Constants.Constants.MaxRollsPerFrame + Constants.Constants.BonusRollsForFinalFrame;
            }
            if (rolls.Count >= Constants.Constants.MaxRollsPerFrame &&
                rolls.Take(Constants.Constants.MaxRollsPerFrame).Sum() == Constants.Constants.MaxPinsPerRoll
                )
            {
                return rolls.Count == Constants.Constants.MaxRollsPerFrame + Constants.Constants.BonusRollsForFinalFrame;
            }
            return rolls.Count == Constants.Constants.MaxRollsPerFrame;
        }
    }

}

