using BowlingBall.Models;

namespace BowlingBall.Interfaces
{
    public interface IScoreCalculator
    {
        int CalculateScore(List<Frame> frames);
    }
}

