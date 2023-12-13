using BowlingBall.Models;

namespace BowlingBall.Interfaces
{
    public interface IScoreCalculationStrategy
    {
        int CalculateScore(List<Frame> frames);
    }
}

