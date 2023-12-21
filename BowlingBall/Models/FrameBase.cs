using BowlingBall.Interfaces;

namespace BowlingBall.Models
{
    public abstract class FrameBase : IFrame
    {
        protected List<int> rolls = new();
        protected IFrameScoringStrategy scoreStrategy;

        protected FrameBase(IFrameScoringStrategy scoreStrategy)
        {
            this.scoreStrategy = scoreStrategy;
        }

        public abstract void AddRoll(int pins);
        public abstract bool IsFrameComplete();
        public int CalculateScore(List<IFrame> frames)
        {
            return scoreStrategy.CalculateScore(this, frames);
        }

        public List<int> GetRolls() => new(rolls);
    }

}

