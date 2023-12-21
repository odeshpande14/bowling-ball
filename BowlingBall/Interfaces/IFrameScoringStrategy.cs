namespace BowlingBall.Interfaces
{
	public interface IFrameScoringStrategy
	{
        int CalculateScore(IFrame frame, List<IFrame> frames);
    }
}

