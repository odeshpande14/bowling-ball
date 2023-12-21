namespace BowlingBall.Interfaces
{
    public interface IFrameFactory
    {
        IFrame CreateFrame(List<int> rolls, bool isFinalFrame);
    }
}

