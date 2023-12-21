using System;
using BowlingBall.Interfaces;

namespace BowlingBall.Models
{
    public class SpareFrame : FrameBase
    {
        public SpareFrame(IFrameScoringStrategy scoreStrategy)
            : base(scoreStrategy) { }

        public SpareFrame(IFrameScoringStrategy scoreStrategy, List<int> rolls)
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
            return rolls.Count == Constants.Constants.MaxRollsPerFrame;
        }
    }

}

